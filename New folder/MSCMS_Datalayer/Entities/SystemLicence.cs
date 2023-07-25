using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class SystemLicence
    {
        public SystemLicence()
        {
            SystemSystemconfigurations = new HashSet<SystemSystemconfiguration>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int MaxUsers { get; set; }
        public int MaxAssets { get; set; }
        public string Database { get; set; } = null!;
        public bool Active { get; set; }
        public int MaxConcurrentUsers { get; set; }

        public virtual ICollection<SystemSystemconfiguration> SystemSystemconfigurations { get; set; }
    }
}
