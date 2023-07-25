using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class Oauth2ProviderGrant
    {
        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public DateTime Expires { get; set; }
        public string RedirectUri { get; set; } = null!;
        public string Scope { get; set; } = null!;
        public long ApplicationId { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string CodeChallenge { get; set; } = null!;
        public string CodeChallengeMethod { get; set; } = null!;

        public virtual Oauth2ProviderApplication Application { get; set; } = null!;
        public virtual StaffUser User { get; set; } = null!;
    }
}
