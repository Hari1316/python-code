using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsProbelpr
    {
        public AssetsProbelpr()
        {
            AssetsAssets = new HashSet<AssetsAsset>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Deleted { get; set; }
        public bool ReadOnly { get; set; }

        public virtual ICollection<AssetsAsset> AssetsAssets { get; set; }
    }
}
