using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class Oauth2ProviderApplication
    {
        public Oauth2ProviderApplication()
        {
            Oauth2ProviderAccesstokens = new HashSet<Oauth2ProviderAccesstoken>();
            Oauth2ProviderGrants = new HashSet<Oauth2ProviderGrant>();
            Oauth2ProviderRefreshtokens = new HashSet<Oauth2ProviderRefreshtoken>();
        }

        public long Id { get; set; }
        public string ClientId { get; set; } = null!;
        public string RedirectUris { get; set; } = null!;
        public string ClientType { get; set; } = null!;
        public string AuthorizationGrantType { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int? UserId { get; set; }
        public bool SkipAuthorization { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual StaffUser? User { get; set; }
        public virtual ICollection<Oauth2ProviderAccesstoken> Oauth2ProviderAccesstokens { get; set; }
        public virtual ICollection<Oauth2ProviderGrant> Oauth2ProviderGrants { get; set; }
        public virtual ICollection<Oauth2ProviderRefreshtoken> Oauth2ProviderRefreshtokens { get; set; }
    }
}
