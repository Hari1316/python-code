﻿using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AuthGroup
    {
        public AuthGroup()
        {
            AuthGroupPermissions = new HashSet<AuthGroupPermission>();
            StaffUserGroups = new HashSet<StaffUserGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<AuthGroupPermission> AuthGroupPermissions { get; set; }
        public virtual ICollection<StaffUserGroup> StaffUserGroups { get; set; }
    }
}
