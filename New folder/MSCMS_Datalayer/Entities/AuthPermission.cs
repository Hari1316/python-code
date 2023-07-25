using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AuthPermission
    {
        public AuthPermission()
        {
            AuthGroupPermissions = new HashSet<AuthGroupPermission>();
            StaffUserUserPermissions = new HashSet<StaffUserUserPermission>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ContentTypeId { get; set; }
        public string Codename { get; set; } = null!;

        public virtual DjangoContentType ContentType { get; set; } = null!;
        public virtual ICollection<AuthGroupPermission> AuthGroupPermissions { get; set; }
        public virtual ICollection<StaffUserUserPermission> StaffUserUserPermissions { get; set; }
    }
}
