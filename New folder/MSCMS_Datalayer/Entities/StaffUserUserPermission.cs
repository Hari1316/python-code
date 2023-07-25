using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class StaffUserUserPermission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public virtual AuthPermission Permission { get; set; } = null!;
        public virtual StaffUser User { get; set; } = null!;
    }
}
