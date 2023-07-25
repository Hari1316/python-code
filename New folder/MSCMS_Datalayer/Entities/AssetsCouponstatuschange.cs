using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsCouponstatuschange
    {
        public AssetsCouponstatuschange()
        {
            InverseNextCr = new HashSet<AssetsCouponstatuschange>();
            InverseNextMl = new HashSet<AssetsCouponstatuschange>();
            InverseNextSt = new HashSet<AssetsCouponstatuschange>();
            InversePrevious = new HashSet<AssetsCouponstatuschange>();
        }

        public int Id { get; set; }
        public string ChangeIn { get; set; } = null!;
        public DateTime? MeasurementTimestampPrev { get; set; }
        public DateTime MeasurementTimestamp { get; set; }
        public double? MetalLoss { get; set; }
        public string? MetalLossStatus { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedTimestamp { get; set; }
        public bool Seen { get; set; }
        public int? AlertMailSent { get; set; }
        public double? CorrosionRate { get; set; }
        public string? CorrosionRateStatus { get; set; }
        public int CouponId { get; set; }
        public int? ErrorLogId { get; set; }
        public int? LastMeasurementId { get; set; }
        public int? NextCrId { get; set; }
        public int? NextMlId { get; set; }
        public int? NextStId { get; set; }
        public int? PreviousId { get; set; }
        public int? SeenById { get; set; }
        public DateTime? SeenOn { get; set; }

        public virtual AssetsCoupon Coupon { get; set; } = null!;
        public virtual AssetsErrorlog? ErrorLog { get; set; }
        public virtual AssetsCouponmeasurement? LastMeasurement { get; set; }
        public virtual AssetsCouponstatuschange? NextCr { get; set; }
        public virtual AssetsCouponstatuschange? NextMl { get; set; }
        public virtual AssetsCouponstatuschange? NextSt { get; set; }
        public virtual AssetsCouponstatuschange? Previous { get; set; }
        public virtual StaffUser? SeenBy { get; set; }
        public virtual ICollection<AssetsCouponstatuschange> InverseNextCr { get; set; }
        public virtual ICollection<AssetsCouponstatuschange> InverseNextMl { get; set; }
        public virtual ICollection<AssetsCouponstatuschange> InverseNextSt { get; set; }
        public virtual ICollection<AssetsCouponstatuschange> InversePrevious { get; set; }
    }
}
