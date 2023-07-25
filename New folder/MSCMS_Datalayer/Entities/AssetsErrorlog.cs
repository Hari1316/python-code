using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsErrorlog
    {
        public AssetsErrorlog()
        {
            AssetsAssetstatuschanges = new HashSet<AssetsAssetstatuschange>();
            AssetsCoupons = new HashSet<AssetsCoupon>();
            AssetsCouponstatuschanges = new HashSet<AssetsCouponstatuschange>();
            AssetsLivedata = new HashSet<AssetsLivedatum>();
        }

        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Message { get; set; }
        public string Type { get; set; } = null!;
        public DateTime CreatedTimestamp { get; set; }
        public int AssetId { get; set; }

        public virtual AssetsAsset Asset { get; set; } = null!;
        public virtual ICollection<AssetsAssetstatuschange> AssetsAssetstatuschanges { get; set; }
        public virtual ICollection<AssetsCoupon> AssetsCoupons { get; set; }
        public virtual ICollection<AssetsCouponstatuschange> AssetsCouponstatuschanges { get; set; }
        public virtual ICollection<AssetsLivedatum> AssetsLivedata { get; set; }
    }
}
