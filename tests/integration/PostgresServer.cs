﻿using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Keycloak.Net.Tests
{
    internal class PostgresServer
    {
        private static DockerClient _dockerClient;

        private static bool _containerStarted = false;

        public static string ContainerName => "test-integration-keycloak-net-postgres";

        private static string DockerImageName => "postgres:13.7-alpine";

        public static int DockerServerPort => 5432;

        public static int ServerPort => 5430;

        private static int DelayTime => 3000;

        internal static string DatabaseConnectionString => 
            $"User ID={DatabaseAdminUser};Password={DatabaseAdminPassword};Host=localhost;Port={ServerPort};Database={DatabaseName};Pooling=true;";

        public static string DatabaseName => "test-database";

        public static string DatabaseAdminUser => "test-admin";

        public static string DatabaseAdminPassword => "test-admin";

        internal static async Task StartsServerContainer(bool recreateContainerIfAvailable = false)
        {
            if (_dockerClient == null)
            {
                _dockerClient = new DockerClientConfiguration(new Uri(GetDockerEndpoint()))
                    .CreateClient();
            }

            if (!ShouldStartNewContanerAsync(recreateContainerIfAvailable).Result)
            {
                return;
            }

            _containerStarted = true;

            var parameters = new CreateContainerParameters
            {
                Name = ContainerName,
                Image = DockerImageName,
                ExposedPorts = new Dictionary<string, EmptyStruct>
                {
                    { $"{DockerServerPort}", default(EmptyStruct) },
                },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        {
                            $"{DockerServerPort}", new List<PortBinding>
                            {
                                new PortBinding {HostPort = ServerPort.ToString()}
                            }
                        }
                    },
                },
                Env = new List<string>
                {
                    $"POSTGRES_PASSWORD={DatabaseAdminPassword}",
                    $"POSTGRES_USER={DatabaseAdminUser}",
                    $"POSTGRES_DB={DatabaseName}"
                }
            };

            await StartsServerContainerInternal(parameters);
        }

        internal static async Task DisposeAsync()
        {
            if (_containerStarted)
            {
                _containerStarted = false;
                await RemoveContainerIfAvailable();
            }
        }

        private static async Task<bool> ShouldStartNewContanerAsync(bool recreateContainerIfAvailable)
        {
            var containers = await _dockerClient.Containers.ListContainersAsync(
              new ContainersListParameters()
              {
                  Limit = 10,
              });

            var existed = containers.Any(c => c.State == "running" && c.Image == DockerImageName && c.Names.Contains($"/{ContainerName}"));

            if (existed && !recreateContainerIfAvailable)
            {
                _containerStarted = true;
                return false;
            }

            await RemoveContainerIfAvailable();

            return true;
        }

        private static async Task RemoveContainerIfAvailable()
        {
            try
            {
                await _dockerClient.Containers.RemoveContainerAsync(ContainerName, new ContainerRemoveParameters
                {
                    Force = true,
                });
            }
            catch (Exception)
            {
                Console.WriteLine($"Error while removing container {ContainerName}. The event will be ignored.");
            }
        }

        private static async Task StartsServerContainerInternal(CreateContainerParameters containerParameters)
        {
            try
            {
                await PullImage();

                Console.WriteLine($"Creating container {ContainerName} from image {DockerImageName}.");

                var response = await _dockerClient.Containers.CreateContainerAsync(containerParameters);

                Console.Out.WriteLine($"Starting container {ContainerName} with id {response.ID}.");
                var success =
                    await _dockerClient.Containers.StartContainerAsync(response.ID, new ContainerStartParameters());

                if (!success)
                {
                    _containerStarted = false;

                    throw new Exception($"Container {ContainerName} is not able to start.");
                }

                _containerStarted = true;

                await WaitForContainerToBeReady();

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }

        private static async Task PullImage()
        {
            Console.WriteLine($"Pulling Image {DockerImageName}.");

            if (_dockerClient == null)
            {
                return;
            }

            await _dockerClient.Images.CreateImageAsync(new ImagesCreateParameters
            {
                FromImage = DockerImageName
            }, null, new Progress<JSONMessage>((message) => { Console.WriteLine(message.ProgressMessage); }));
        }

        private static string GetDockerEndpoint()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return "unix:///var/run/docker.sock";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return "npipe://./pipe/docker_engine";
            }

            throw new NotSupportedException();
        }

        private static async Task WaitForContainerToBeReady()
        {
            var iRetry = 0;
            const int maxRetry = 60;

            while (iRetry++ < maxRetry)
            {
                try
                {
                    var connection = new Npgsql.NpgsqlConnection(DatabaseConnectionString);

                    connection.Open();

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        return;
                    }
                }
                catch (Exception)
                {

                }

                Console.WriteLine("Postgres server is not ready. Will retry again.");
                await Task.Delay(DelayTime);
            }

            if (iRetry >= maxRetry)
            {
                throw new Exception($"Unable to connect to Postgres after {maxRetry} retries.");
            }
        }
    }
}
