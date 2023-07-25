using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class StaffApplicationconfig
    {
        public int Id { get; set; }
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
        public int? LastModifiedUserId { get; set; }
        public int? UserId { get; set; }

        public virtual StaffUser? LastModifiedUser { get; set; }
        public virtual StaffUser? User { get; set; }
    }
}
