using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Keycloak.Net.Tests
{
    internal class KeyCloakServer
    {

        private static DockerClient _dockerClient;

        private static bool _containerStarted = false;

        private static string ContainerName => "test-integration-keycloak-net";

        private static string DockerImageName => "jboss/keycloak:16.1.1";

        private static int ServerPort => 8080;

        private static int DelayTime => 3000;

        internal static string keyCloakEndpoint => $"http://localhost:{ServerPort}";

        internal static string keyCloakAdminUser => "test-admin";

        internal static string keyCloakAdminPassword => "test-admin";

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
                    { "8080", default(EmptyStruct) },
                    { "8443", default(EmptyStruct) },
                },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        {
                            "8080", new List<PortBinding>
                            {
                                new PortBinding {HostPort = ServerPort.ToString()}
                            }
                        },
                        {
                            "8443", new List<PortBinding>
                            {
                                new PortBinding {HostPort = "8443"}
                            }
                        }
                    },
                },
                Env = new List<string>
                {
                    $"KEYCLOAK_PASSWORD={keyCloakAdminPassword}",
                    $"KEYCLOAK_USER={keyCloakAdminUser}"
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
            catch(Exception ex)
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
                    using var httpClient = new HttpClient();
                    var result = await httpClient.GetAsync($"{keyCloakEndpoint}/auth");
                    if (result.IsSuccessStatusCode)
                    {
                        return;
                    }
                }
                catch (Exception)
                {

                }

                Console.WriteLine("Keycloak server is not ready. Will retry again.");
                await Task.Delay(DelayTime);
            }

            if (iRetry >= maxRetry)
            {
                throw new Exception($"Unable to connect to keycloak after {maxRetry} retries.");
            }
        }
    }
}
