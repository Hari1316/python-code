using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class Oauth2ProviderRefreshtoken
    {
        public long Id { get; set; }
        public string Token { get; set; } = null!;
        public long? AccessTokenId { get; set; }
        public long ApplicationId { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? Revoked { get; set; }

        public virtual Oauth2ProviderAccesstoken? AccessToken { get; set; }
        public virtual Oauth2ProviderApplication Application { get; set; } = null!;
        public virtual StaffUser User { get; set; } = null!;
        public virtual Oauth2ProviderAccesstoken? Oauth2ProviderAccesstoken { get; set; }
    }
}
