using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsModbusstoreparameter
    {
        public AssetsModbusstoreparameter()
        {
            AssetsAssetModbusStoreCrParams = new HashSet<AssetsAsset>();
            AssetsAssetModbusStoreMlParams = new HashSet<AssetsAsset>();
            AssetsAssetmodels = new HashSet<AssetsAssetmodel>();
            AssetsCouponModbusStoreCrParams = new HashSet<AssetsCoupon>();
            AssetsCouponModbusStoreMlParams = new HashSet<AssetsCoupon>();
        }

        public int Id { get; set; }
        public string Byteorder { get; set; } = null!;
        public string Wordorder { get; set; } = null!;
        public int? HighValueRegisterAddress { get; set; }
        public int? LowValueRegisterAddress { get; set; }
        public int ScalingFactor { get; set; }
        public int ModbusDataTypeId { get; set; }

        public virtual AssetsModbusdatatype ModbusDataType { get; set; } = null!;
        public virtual ICollection<AssetsAsset> AssetsAssetModbusStoreCrParams { get; set; }
        public virtual ICollection<AssetsAsset> AssetsAssetModbusStoreMlParams { get; set; }
        public virtual ICollection<AssetsAssetmodel> AssetsAssetmodels { get; set; }
        public virtual ICollection<AssetsCoupon> AssetsCouponModbusStoreCrParams { get; set; }
        public virtual ICollection<AssetsCoupon> AssetsCouponModbusStoreMlParams { get; set; }
    }
}
