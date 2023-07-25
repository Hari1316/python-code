using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsProtocol
    {
        public AssetsProtocol()
        {
            AssetsAssets = new HashSet<AssetsAsset>();
            AssetsDevices = new HashSet<AssetsDevice>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CodeName { get; set; } = null!;

        public virtual ICollection<AssetsAsset> AssetsAssets { get; set; }
        public virtual ICollection<AssetsDevice> AssetsDevices { get; set; }
    }
}
