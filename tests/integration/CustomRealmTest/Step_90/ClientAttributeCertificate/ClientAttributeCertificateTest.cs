using Xunit;

namespace Keycloak.Net.Tests.CustomRealmTest
{
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class ClientAttributeCertificateTest : KeycloakClientTests
    {
        //public ClientAttributeCertificateTest(KeycloakFixture fixture)
        //{
        //    _keycloak = fixture.TestClient;
        //    _fixture = fixture;
        //    _realm = fixture.Realm._Realm;
        //}

        //#region Properties

        //private readonly KeycloakClient _keycloak;
        //private readonly KeycloakFixture _fixture;
        //private readonly string _realm;

        //private static KeyValuePair<string, object> _certAttr;
        //private static byte[] _certificate;

        //#endregion

        //[Fact, TestPriority(-10)]
        //public async Task GetKeyInfoAsync()
        //{
        //    _fixture.Client = (await _keycloak.GetClientsAsync(_realm, _fixture.Client.ClientId!))!.Single();
        //    //_certAttr = _fixture.Client.Attributes!.First();
        //    var result = await _keycloak.GetKeyInfoAsync(_realm, _fixture.Client.Id!, ""); // _certAttr.Key
        //    result.Should().NotBeNull();
        //}
        
        //[Fact, TestPriority(-9)]
        //public async Task GenerateCertificateWithNewKeyPairAsync()
        //{
        //    var result = await _keycloak.GenerateCertificateWithNewKeyPairAsync(_realm, _fixture.Client.Id!, _certAttr.Key);
        //    result.Should().NotBeNull();
        //}

        //[Fact, TestPriority(-8)]
        //public async Task GetKeyStoreForClientAsync()
        //{
        //    _certificate = await _keycloak.GetKeyStoreForClientAsync(_realm, _fixture.Client.Id!, _certAttr.Key, new KeyStoreConfig
        //    {
        //        Format = "PKCS12",
        //        KeyAlias = "key",
        //        KeyPassword = "password",
        //        RealmAlias = _realm,
        //        RealmCertificate = true,
        //        StorePassword = "password"
        //    });
        //    _certificate.Should().NotBeNull();
        //    await File.WriteAllBytesAsync("cert.pfx", _certificate);
        //}

        //[Fact]
        //public async Task GenerateCertificateWithNewKeyPairAndGetKeyStoreAsync()
        //{
        //    var result = await _keycloak.GenerateCertificateWithNewKeyPairAndGetKeyStoreAsync(_realm, _fixture.Client.Id!, _certAttr.Key, new KeyStoreConfig
        //    {
        //        Format = "PKCS12",
        //        KeyAlias = "key",
        //        KeyPassword = "password",
        //        RealmAlias = _realm,
        //        RealmCertificate = true,
        //        StorePassword = "password"
        //    });
        //    result.Should().NotBeNull();
        //}

        //[Fact(Skip = "Not working"), TestPriority(-7)]
        //public async Task UploadCertificateWithPrivateKeyAsync()
        //{
        //    var result = await _keycloak.UploadCertificateWithPrivateKeyAsync(_realm, _fixture.Client.Id!, _certAttr.Key, "cert.pfx");
        //    result.Should().NotBeNull();
        //}

        //[Fact(Skip = "Not working"), TestPriority(-7)]
        //public async Task UploadCertificateWithoutPrivateKeyAsync()
        //{
        //    var result = await _keycloak.UploadCertificateWithoutPrivateKeyAsync(_realm, _fixture.Client.Id!, _certAttr.Key, "cert.pfx");
        //    result.Should().NotBeNull();
        //}
    }
}
