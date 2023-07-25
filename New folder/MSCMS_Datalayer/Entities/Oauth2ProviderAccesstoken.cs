using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class Oauth2ProviderAccesstoken
    {
        public long Id { get; set; }
        public string Token { get; set; } 
        public DateTime Expires { get; set; }
        public string? Scope { get; set; }
        public long? ApplicationId { get; set; }
        public int? UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public long? SourceRefreshTokenId { get; set; }

        public virtual Oauth2ProviderApplication? Application { get; set; }
        public virtual Oauth2ProviderRefreshtoken? SourceRefreshToken { get; set; }
        public virtual StaffUser? User { get; set; }
        public virtual Oauth2ProviderRefreshtoken? Oauth2ProviderRefreshtoken { get; set; }
    }
}
