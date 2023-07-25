using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsAssetmeasurement
    {
        public AssetsAssetmeasurement()
        {
            AssetsAssetstatuschanges = new HashSet<AssetsAssetstatuschange>();
            AssetsLivedata = new HashSet<AssetsLivedatum>();
        }

        public int Id { get; set; }
        public double? RawData { get; set; }
        public double? MetalLoss { get; set; }
        public double CorrosionRate { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime MeasurementTimestamp { get; set; }
        public int AssetId { get; set; }
        public double LongTermCorrosionRate { get; set; }
        public string? OpcTag { get; set; }
        public long MeasurementTimestampUnix { get; set; }
        public int? CreatedById { get; set; }
        public bool IsManualEntry { get; set; }

        public virtual AssetsAsset Asset { get; set; } = null!;
        public virtual StaffUser? CreatedBy { get; set; }
        public virtual ICollection<AssetsAssetstatuschange> AssetsAssetstatuschanges { get; set; }
        public virtual ICollection<AssetsLivedatum> AssetsLivedata { get; set; }
    }
}
