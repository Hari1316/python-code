using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsProbetype
    {
        public AssetsProbetype()
        {
            AssetsProbes = new HashSet<AssetsProbe>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public bool ReadOnly { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<AssetsProbe> AssetsProbes { get; set; }
    }
}
