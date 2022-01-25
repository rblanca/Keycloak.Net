using System.IO;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.ClientAttributeCertificate;

namespace Keycloak.Net
{
    /// <remarks>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_client_attribute_certificate_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/clients/{clientId}/certificates/{attribute}
        /// Get key info.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="attribute"></param>
        public async Task<Certificate> GetKeyInfoAsync(string realm, string clientId, string attribute)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/certificates/{attribute}")
                .GetJsonAsync<Certificate>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/clients/{id}/certificates/{attr}/download <br/>
        /// Get a keystore file for the client, containing private key and public certificate. 
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="attribute"></param>
        /// <param name="keyStoreConfig">keystore configuration as JSON</param>
        public async Task<byte[]> GetKeyStoreForClientAsync(
            string realm, 
            string clientId, 
            string attribute,
            KeyStoreConfig keyStoreConfig)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/certificates/{attribute}/download")
                .PostJsonAsync(keyStoreConfig)
                .ReceiveBytes()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/clients/{id}/certificates/{attr}/generate <br/>
        /// Generate a new certificate with new key pair.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="attribute"></param>
        public async Task<Certificate> GenerateCertificateWithNewKeyPairAsync(
            string realm, 
            string clientId,
            string attribute)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/certificates/{attribute}/generate")
                .PostAsync()
                .ReceiveJson<Certificate>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/clients/{id}/certificates/{attr}/generate-and-download <br/>
        /// Generate a new keypair and certificate, and get the private key file. Generates a keypair and certificate and serves the private key in a specified keystore format.
        /// Only generated public certificate is saved in Keycloak DB - the private key is not.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="attribute"></param>
        /// <param name="keyStoreConfig">keystore configuration as JSON</param>
        public async Task<byte[]> GenerateCertificateWithNewKeyPairAndGetKeyStoreAsync(
            string realm, 
            string clientId,
            string attribute, 
            KeyStoreConfig keyStoreConfig)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/certificates/{attribute}/generate-and-download")
                .PostJsonAsync(keyStoreConfig)
                .ReceiveBytes()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/clients/{id}/certificates/{attr}/upload <br/>
        /// Upload certificate and eventually private key.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="attribute"></param>
        /// <param name="fileName"></param>
        public async Task<Certificate> UploadCertificateWithPrivateKeyAsync(
            string realm, 
            string clientId,
            string attribute, 
            string fileName)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/certificates/{attribute}/upload")
                .PostMultipartAsync(content => content.AddFile(Path.GetFileName(fileName), fileName)) // Path.GetDirectoryName(fileName)
                .ReceiveJson<Certificate>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/clients/{id}/certificates/{attr}/upload-certificate <br/>
        /// Upload only certificate, not private key.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="attribute"></param>
        /// <param name="fileName"></param>
        public async Task<Certificate> UploadCertificateWithoutPrivateKeyAsync(
            string realm, 
            string clientId,
            string attribute, 
            string fileName)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/certificates/{attribute}/upload-certificate")
                .PostMultipartAsync(content => content.AddFile(Path.GetFileName(fileName), Path.GetDirectoryName(fileName)))
                .ReceiveJson<Certificate>()
                .ConfigureAwait(false);
            return response;
        }
    }
}