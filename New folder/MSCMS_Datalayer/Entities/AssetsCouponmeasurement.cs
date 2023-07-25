using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsCouponmeasurement
    {
        public AssetsCouponmeasurement()
        {
            AssetsCoupons = new HashSet<AssetsCoupon>();
            AssetsCouponstatuschanges = new HashSet<AssetsCouponstatuschange>();
        }

        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
        public DateTime InstallTst { get; set; }
        public DateTime RemovalTst { get; set; }
        public double FinalWeight { get; set; }
        public double TotalExposure { get; set; }
        public double MetalLoss { get; set; }
        public double CorrosionRate { get; set; }
        public int CouponId { get; set; }
        public int? LastModifiedUserId { get; set; }

        public virtual AssetsCoupon Coupon { get; set; } = null!;
        public virtual StaffUser? LastModifiedUser { get; set; }
        public virtual ICollection<AssetsCoupon> AssetsCoupons { get; set; }
        public virtual ICollection<AssetsCouponstatuschange> AssetsCouponstatuschanges { get; set; }
    }
}
