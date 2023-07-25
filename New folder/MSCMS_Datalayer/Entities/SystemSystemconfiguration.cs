using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class SystemSystemconfiguration
    {
        public int Id { get; set; }
        public string EmailServerAddress { get; set; } = null!;
        public string SmsServerAddress { get; set; } = null!;
        public string EmailUsername { get; set; } = null!;
        public string EmailPassword { get; set; } = null!;
        public string SmsEmailAddress { get; set; } = null!;
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
        public int ActiveLicenceId { get; set; }
        public int? LastModifiedUserId { get; set; }
        public int EmailServerPort { get; set; }
        public bool EmailNotificationsEnabled { get; set; }
        public int PasswordExpiryDuration { get; set; }
        public int PasswordExpiryNotification { get; set; }

        public virtual SystemLicence ActiveLicence { get; set; } = null!;
        public virtual StaffUser? LastModifiedUser { get; set; }
    }
}
