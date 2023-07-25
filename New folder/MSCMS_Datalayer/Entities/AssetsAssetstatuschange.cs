using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsAssetstatuschange
    {
        public AssetsAssetstatuschange()
        {
            InverseNextHw = new HashSet<AssetsAssetstatuschange>();
            InverseNextLtcr = new HashSet<AssetsAssetstatuschange>();
            InverseNextMl = new HashSet<AssetsAssetstatuschange>();
            InverseNextSt = new HashSet<AssetsAssetstatuschange>();
            InversePrevious = new HashSet<AssetsAssetstatuschange>();
        }

        public int Id { get; set; }
        public string ChangeIn { get; set; } = null!;
        public DateTime? MeasurementTimestampPrev { get; set; }
        public DateTime MeasurementTimestamp { get; set; }
        public double? LongTermCorrosionRate { get; set; }
        public double? MetalLoss { get; set; }
        public string? LongTermCorrosionRateStatus { get; set; }
        public string? MetalLossStatus { get; set; }
        public string? HardwareStatus { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedTimestamp { get; set; }
        public int AssetId { get; set; }
        public int? LastMeasurementId { get; set; }
        public int? PreviousId { get; set; }
        public int? ErrorLogId { get; set; }
        public bool Seen { get; set; }
        public int? SeenById { get; set; }
        public int? AlertMailSent { get; set; }
        public int? NextHwId { get; set; }
        public int? NextLtcrId { get; set; }
        public int? NextMlId { get; set; }
        public int? NextStId { get; set; }
        public DateTime? SeenOn { get; set; }

        public virtual AssetsAsset Asset { get; set; } = null!;
        public virtual AssetsErrorlog? ErrorLog { get; set; }
        public virtual AssetsAssetmeasurement? LastMeasurement { get; set; }
        public virtual AssetsAssetstatuschange? NextHw { get; set; }
        public virtual AssetsAssetstatuschange? NextLtcr { get; set; }
        public virtual AssetsAssetstatuschange? NextMl { get; set; }
        public virtual AssetsAssetstatuschange? NextSt { get; set; }
        public virtual AssetsAssetstatuschange? Previous { get; set; }
        public virtual StaffUser? SeenBy { get; set; }
        public virtual ICollection<AssetsAssetstatuschange> InverseNextHw { get; set; }
        public virtual ICollection<AssetsAssetstatuschange> InverseNextLtcr { get; set; }
        public virtual ICollection<AssetsAssetstatuschange> InverseNextMl { get; set; }
        public virtual ICollection<AssetsAssetstatuschange> InverseNextSt { get; set; }
        public virtual ICollection<AssetsAssetstatuschange> InversePrevious { get; set; }
    }
}
