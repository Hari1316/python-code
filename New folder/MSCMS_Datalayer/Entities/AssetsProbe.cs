using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsProbe
    {
        public AssetsProbe()
        {
            AssetsAssets = new HashSet<AssetsAsset>();
        }

        public int Id { get; set; }
        public string ElementId { get; set; } = null!;
        public double Thickness { get; set; }
        public double ProbeLife { get; set; }
        public bool ReadOnly { get; set; }
        public bool Deleted { get; set; }
        public int ProbeTypeId { get; set; }

        public virtual AssetsProbetype ProbeType { get; set; } = null!;
        public virtual ICollection<AssetsAsset> AssetsAssets { get; set; }
    }
}
