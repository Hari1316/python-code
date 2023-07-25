using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsAssetmodeldatatype
    {
        public AssetsAssetmodeldatatype()
        {
            AssetsAssetmodels = new HashSet<AssetsAssetmodel>();
        }

        public int Id { get; set; }
        public string DataType { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<AssetsAssetmodel> AssetsAssetmodels { get; set; }
    }
}
