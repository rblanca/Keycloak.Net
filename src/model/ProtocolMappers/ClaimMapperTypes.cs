using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keycloak.Net.Model.ProtocolMappers
{
    public static class ClaimMapperTypes
    {
        //Claims Parameter Token
        public const string OidcClaimsParam = "oidc-claims-param-token-mapper";

        //Audience
        public const string OidcAudience = "oidc-audience-mapper";

        //User Session Note
        public const string OidcUserSessionModelNote = "oidc-usersessionmodel-note-mapper";

        //Group Membership
        public const string OidcGroupMembership = "oidc-group-membership-mapper";

        //User Address
        public const string OidcAddress = "oidc-address-mapper";

        //Role Name Mapper
        public const string OidcRoleName = "oidc-role-name-mapper";

        //Hardcoded Claim
        public const string OidcHardcodedClaim = "oidc-hardcoded-claim-mapper";

        //Hardcoded Role
        public const string OidcHardcodedRole = "oidc-hardcoded-role-mapper";

        //Pairwise Subject Identifier
        public const string OidcSha256PairwiseSub = "oidc-sha256-pairwise-sub-mapper";

        //Allowed Web Origins
        public const string OidcAllowedOrigins = "oidc-allowed-origins-mapper";

        //User Attribute
        public const string OidcUserModelAttribute = "oidc-usermodel-attribute-mapper";

        //Audience Resolve
        public const string OidcUserAudienceResolve = "oidc-audience-resolve-mapper";

        //User Realm Role
        public const string OidcUserModelRealmRole = "oidc-usermodel-realm-role-mapper";
        
        //User Client Role
        public const string OidcUserModelClientRole = "oidc-usermodel-client-role-mapper";

        //User Property
        public const string OidcUserModelProperty = "oidc-usermodel-property-mapper";

        //User's Full Name
        public const string OidcFullName = "oidc-full-name-mapper";

        //SAML Role List
        public const string SamlRoleList = "saml-role-list-mapper";
    }
}
