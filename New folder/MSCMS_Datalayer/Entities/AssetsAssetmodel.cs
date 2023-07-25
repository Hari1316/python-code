using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsAssetmodel
    {
        public AssetsAssetmodel()
        {
            AssetsAssets = new HashSet<AssetsAsset>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool ReadOnly { get; set; }
        public bool Deleted { get; set; }
        public string? MetalLossFormula { get; set; }
        public string Manufacturer { get; set; } = null!;
        public int DataTypeId { get; set; }
        public int? ModbusStoreParamsId { get; set; }
        public string MeasurementMethod { get; set; } = null!;

        public virtual AssetsAssetmodeldatatype DataType { get; set; } = null!;
        public virtual AssetsModbusstoreparameter? ModbusStoreParams { get; set; }
        public virtual ICollection<AssetsAsset> AssetsAssets { get; set; }
    }
}
