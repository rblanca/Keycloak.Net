using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.AuthenticationManagement;
using Xunit;

namespace Keycloak.Net.Tests
{
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class AuthenticationManagementTest : KeycloakClientTests
    {
        public AuthenticationManagementTest(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        private static readonly AuthenticationFlowWithExecution _childFlow = new AuthenticationFlowWithExecution
        {
            Alias = "childFlow",
            Type = "basic-flow",
            Description = "child flow",
            Provider = "registration-page-form"
        };

        private static AuthenticationFlowExecutionInfo _flowExecutionInfo;

        #endregion

        [Fact, TestPriority(-30)]
        public async Task GetAuthenticatorProvidersAsync()
        {
            var result = (await _keycloak.GetAuthenticatorProvidersAsync(_realm)).ToList();
            result.Should().NotBeNullOrEmpty();
            _fixture.AuthenticatorProvider = result[0];
        }

        [Fact, TestPriority(0)]
        public async Task GetClientAuthenticatorProvidersAsync()
        {
            var result = await _keycloak.GetClientAuthenticatorProvidersAsync(_realm);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact, TestPriority(0)]
        public async Task GetAuthenticatorProviderConfigurationDescriptionAsync()
        {
            var result = await _keycloak.GetAuthenticatorProviderConfigurationDescriptionAsync(_realm, _fixture.AuthenticatorProvider.Id!);
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(0)]
        public async Task GetConfigurationDescriptionsForAllClientsAsync()
        {
            var result = await _keycloak.GetConfigurationDescriptionsForAllClientsAsync(_realm);
            result.Should().NotBeNull();
        }

        //[Fact(Skip = "Not working yet")]
        //public async Task GetAuthenticatorConfigurationAsync()
        //{
        //    var configurationId = ""; //TODO
        //    if (configurationId != null)
        //    {
        //        var result = await _keycloak.GetAuthenticatorConfigurationAsync(_realm, configurationId);
        //        Assert.NotNull(result);
        //    }
        //}

        [Fact, TestPriority(-20)]
        public async Task CreateAuthenticationFlowAsync()
        {
            var result = await _keycloak.CreateAuthenticationFlowAsync(_realm, _fixture.AuthenticationFlow);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(0)]
        public async Task DuplicateAuthenticationFlowAsync()
        {
            var result = await _keycloak.DuplicateAuthenticationFlowAsync(_realm, _fixture.AuthenticationFlow.Alias!, $"{_fixture.AuthenticationFlow.Alias!}2");
            result.Should().BeTrue();
        }

        [Fact, TestPriority(-19)]
        public async Task GetAuthenticationFlowsAsync()
        {
            var results = (await _keycloak.GetAuthenticationFlowsAsync(_realm)).ToList();
            results.Should().NotBeNullOrEmpty();
            _fixture.AuthenticationFlow = results.Single(a => a.Alias!.Equals(_fixture.AuthenticationFlow.Alias));
            _fixture.AuthenticationFlow.Id.Should().NotBeNullOrEmpty();
        }

        [Fact, TestPriority(0)]
        public async Task GetAuthenticationFlowByIdAsync()
        {
            var result = await _keycloak.GetAuthenticationFlowByIdAsync(_realm, _fixture.AuthenticationFlow.Id!);
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(2)]
        public async Task UpdateAuthenticationFlowAsync()
        {
            var result = await _keycloak.UpdateAuthenticationFlowAsync(_realm, _fixture.AuthenticationFlow.Id!, _fixture.AuthenticationFlow);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task DeleteAuthenticationFlowAsync()
        {
            var result = await _keycloak.DeleteAuthenticationFlowAsync(_realm, _fixture.AuthenticationFlow.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(-10)]
        public async Task AddAuthenticationFlowExecutionAsync()
        {
            var result = await _keycloak.AddAuthenticationFlowExecutionAsync(_realm, _fixture.AuthenticationFlow.Alias!, new AuthenticationFlowExecution{Provider = _fixture.AuthenticatorProvider.Id!});
            result.Should().BeTrue();
        }

        [Fact, TestPriority(-9)]
        public async Task AddAuthenticationFlowAndExecutionToAuthenticationFlowAsync()
        {
            var result = await _keycloak.AddAuthenticationFlowAndExecutionToAuthenticationFlowAsync(_realm, _fixture.AuthenticationFlow.Alias!, _childFlow);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(-8)]
        public async Task GetAuthenticationFlowExecutionsAsync()
        {
            var results = (await _keycloak.GetAuthenticationFlowExecutionsAsync(_realm, _fixture.AuthenticationFlow.Alias!)).ToList();
            results.Should().NotBeNullOrEmpty();
            _flowExecutionInfo = results.Single(r => r.DisplayName!.Equals(_childFlow.Alias));
        }

        [Fact, TestPriority(0)]
        public async Task GetAuthenticationExecutionAsync()
        {
            var result = await _keycloak.GetAuthenticationExecutionAsync(_realm, _flowExecutionInfo.Id!);
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(2)]
        public async Task UpdateAuthenticationFlowExecutionsAsync()
        {
            var result = await _keycloak.UpdateAuthenticationFlowExecutionsAsync(_realm, _fixture.AuthenticationFlow.Alias!, _flowExecutionInfo);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(2)]
        public async Task UpdateAuthenticationExecutionConfigurationAsync()
        {
            var result = await _keycloak.UpdateAuthenticationExecutionConfigurationAsync(_realm, _flowExecutionInfo.Id!, new AuthenticatorConfig
            {
                Id = _flowExecutionInfo.Id,
                Alias = $"{_childFlow.Alias}Config",
            });
            result.Should().BeTrue();
        }

        [Fact, TestPriority(0)]
        public async Task LowerAuthenticationExecutionPriorityAsync()
        {
            var result = await _keycloak.LowerAuthenticationExecutionPriorityAsync(_realm, _flowExecutionInfo.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(0)]
        public async Task RaiseAuthenticationExecutionPriorityAsync()
        {
            var result = await _keycloak.RaiseAuthenticationExecutionPriorityAsync(_realm, _flowExecutionInfo.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task DeleteAuthenticationExecutionAsync()
        {
            var result = await _keycloak.DeleteAuthenticationExecutionAsync(_realm, _flowExecutionInfo.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(-10)]
        public async Task GetFormActionProvidersAsync()
        {
            var results = (await _keycloak.GetFormActionProvidersAsync(_realm)).ToList();
            results.Should().NotBeNullOrEmpty();
            _fixture.FormActionProvider = results[0];
        }

        [Fact, TestPriority(-10)]
        public async Task GetFormProvidersAsync()
        {
            var result = (await _keycloak.GetFormProvidersAsync(_realm)).ToList();
            result.Should().NotBeNullOrEmpty();
        }

        //[Fact, TestPriority(-10)]
        //public async Task RegisterRequiredActionAsync()
        //{
        //    var result = await _keycloak.RegisterRequiredActionAsync(_realm, new RequiredAction
        //    {
        //        Name = _fixture.RequiredActionProvider.Name,
        //        ProviderId = _fixture.RequiredActionProvider.ProviderId
        //    });
        //    result.Should().BeTrue();
        //}

        [Fact, TestPriority(-9)]
        public async Task GetRequiredActionsAsync()
        {
            var results = (await _keycloak.GetRequiredActionsAsync(_realm)).ToList();
            results.Should().NotBeNullOrEmpty();
            _fixture.RequiredActionProvider = results[0];
        }

        [Fact, TestPriority(0)]
        public async Task GetRequiredActionByAliasAsync()
        {
            var result = await _keycloak.GetRequiredActionByAliasAsync(_realm, _fixture.RequiredActionProvider.Alias!);
            result.Should().BeEquivalentTo(_fixture.RequiredActionProvider, opt => opt.Using(new IgnoreNullMembersInExpectation(_fixture.RequiredActionProvider)));
        }

        [Fact, TestPriority(2)]
        public async Task UpdateRequiredActionAsync()
        {
            var result = await _keycloak.UpdateRequiredActionAsync(_realm, _fixture.RequiredActionProvider.Alias!, _fixture.RequiredActionProvider);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(0)]
        public async Task LowerRequiredActionPriorityAsync()
        {
            var result = await _keycloak.LowerRequiredActionPriorityAsync(_realm, _fixture.RequiredActionProvider.Alias!);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(0)]
        public async Task RaiseRequiredActionPriorityAsync()
        {
            var result = await _keycloak.RaiseRequiredActionPriorityAsync(_realm, _fixture.RequiredActionProvider.Alias!);
            result.Should().BeTrue();
        }

        //[Fact, TestPriority(4)]
        //public async Task DeleteRequiredActionAsync()
        //{
        //    var result = await _keycloak.DeleteRequiredActionAsync(_realm, _fixture.RequiredActionProvider.Alias!);
        //    result.Should().BeTrue();
        //}

        [Fact, TestPriority(0)]
        public async Task GetUnregisteredRequiredActionsAsync()
        {
            var results = (await _keycloak.GetUnregisteredRequiredActionsAsync(_realm)).ToList();
            results.Should().NotBeNullOrEmpty();
        }
    }
}