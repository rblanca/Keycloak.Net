# Keycloak.Net

![Icon](./logo.jpg)

forked from [lvermeulen/Keycloak.Net](https://github.com/lvermeulen/Keycloak.Net)

[![Build status](https://ci.appveyor.com/api/projects/status/c9npduu2dp9ljlps?svg=true)](https://ci.appveyor.com/project/lvermeulen/keycloak-net)
[![license](https://img.shields.io/github/license/lvermeulen/Keycloak.Net.svg?maxAge=2592000)](https://github.com/lvermeulen/Keycloak.Net/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/Keycloak.Net.svg?maxAge=2592000)](https://www.nuget.org/packages/Keycloak.Net/)
![downloads](https://img.shields.io/nuget/dt/Keycloak.Net)
![.net4.5.2](https://img.shields.io/badge/.net-4.5.2-yellowgreen.svg)
![.netstandard 1.4](https://img.shields.io/badge/netstandard-1.4-yellowgreen.svg)
[![FOSSA Status](https://app.fossa.com/api/projects/custom%2B11767%2Fgithub.com%2Flvermeulen%2FKeycloak.Net.svg?type=shield)](https://app.fossa.com/projects/custom%2B11767%2Fgithub.com%2Flvermeulen%2FKeycloak.Net?ref=badge_shield)

C# SDK client for [Keycloak](https://www.keycloak.org/).

See documentation at [https://www.keycloak.org/documentation](https://www.keycloak.org/documentation).

- [Keycloak.Net](#keycloaknet)
  - [Features](#features)
  - [Build](#build)
  - [Usage](#usage)
  - [Tests](#tests)
    - [Unit Test](#unit-test)
    - [Integration Test](#integration-test)
  - [Contributing](#contributing)

## Features

- [X] Attack Detection
- [X] Authentication Management
- [X] Client Attribute Certificate
- [X] Client Initial Access
- [X] Client Registration Policy
- [X] Client Role Mappings
- [X] Client Scopes
- [X] Clients
- [X] Component
- [X] Groups
- [X] Identity Providers
- [X] Key
- [X] Protocol Mappers
- [X] Realms Admin
- [X] Role Mapper
- [X] Roles
- [X] Roles (by ID)
- [X] Scope Mappings
- [X] User Storage Provider
- [X] Users
- [X] Root

## Build

1. Build the solution and package the Nuget package from the ['`./src/core/Keycloak.Net.csproj`' project](./src/core).
   - Ensure that the nuget package version number follows the assembly's version and uses [SemVer](https://semver.org/).
   - The major version number should follow the same major release of Keycloak Server.
     - E.g. `Keycloak.Net` 16.x.x releases should support Keycloak Server 16.x.x releases.
   - The minor version should support the following changes:
     - New functionalities added in the Keycloak.Net to support the existing APIs of Keycloak Server.
     - New functionalities added in Keycloak Server in a backwards compatible manner within the same major release.
   - The patch version is added to support minor bugfixes to support existing Keycloak Server APIs of that major release version.
2. Upload the Nuget package to your source repository with the release number mentioned above.

## Usage

1. Install the standard Nuget package into your .NET application:
   - Package Manager

   ```cmd
   Install-Package Keycloak.Net -Version x.x.x
   ```

   - CLI

   ```cmd
   dotnet add package --version x.x.x Keycloak.Net
   ```

2. Initialize the Keycloak Client with the following line:

   ```csharp
   var keycloakClient = new KeycloakClient("http://keycloak.local", "realm", "admin-cli-client", "user", "password");
   var masterRealm = keycloakClient.GetRealmAsync("realm");
   ```

## Tests

### Unit Test

The unit tests are written to mainly cover common solutions such as the following:

- [Keycloak.Net.Shared](./src/shared)
- [Keycloak.Net.Model](./src/model)

### Integration Test

The integration tests requires a hosted Keycloak Server to run. If there's no Keycloak Server available, you can easily deploy [a scaffolded version of the Keycloak Server](./pipeline/helm/keycloak.yml) using [Helm](https://helm.sh/docs/).

``` cmd
helm repo add bitnami https://charts.bitnami.com/bitnami
helm install my-keycloak bitnami/keycloak --namespace dev --create-namespace -f keycloak.yml --atomic
```

All tests should then run sequentially from Step1_0 to StepX.

## Contributing

Contributions and bug reports are always welcomed. If you wish to contribute, please submit your Pull Requests for review and merge.

- Always create branches for different issues found and submit as separate Pull Requests.
- Always pull and rebase changes from `main` branch to keep a clean git history.
- Please [squash your commits](https://stackoverflow.com/a/50880042) into a single commit if there are too many commits on your branch before submitting a Pull Request.
