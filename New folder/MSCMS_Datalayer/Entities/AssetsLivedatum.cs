using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsLivedatum
    {
        public int Id { get; set; }
        public double ShortTermCorrosionRate { get; set; }
        public double LongTermCorrosionRate { get; set; }
        public int? LastMeasurementId { get; set; }
        public string HardwareStatus { get; set; } = null!;
        public string LongTermCorrosionRateStatus { get; set; } = null!;
        public double? MetalLoss { get; set; }
        public string MetalLossStatus { get; set; } = null!;
        public string ShortTermCorrosionRateStatus { get; set; } = null!;
        public string Status { get; set; } = null!;
        public long? LastMeasurementTimestampUnix { get; set; }
        public int? ErrorLogId { get; set; }
        public bool SkipNotifyLtcr { get; set; }

        public virtual AssetsErrorlog? ErrorLog { get; set; }
        public virtual AssetsAssetmeasurement? LastMeasurement { get; set; }
        public virtual AssetsAsset? AssetsAsset { get; set; }
    }
}
