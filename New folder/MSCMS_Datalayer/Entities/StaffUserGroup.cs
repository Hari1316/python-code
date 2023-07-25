using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class StaffUserGroup
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public virtual AuthGroup Group { get; set; } = null!;
        public virtual StaffUser User { get; set; } = null!;
    }
}
