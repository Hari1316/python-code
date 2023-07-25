using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsCoupon
    {
        public AssetsCoupon()
        {
            AssetsCouponmeasurements = new HashSet<AssetsCouponmeasurement>();
            AssetsCouponstatuschanges = new HashSet<AssetsCouponstatuschange>();
        }

        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
        public string Type { get; set; } = null!;
        public int Sequence { get; set; }
        public string Alloy { get; set; } = null!;
        public double AlloyDensity { get; set; }
        public string Shape { get; set; } = null!;
        public int? NumberOfHoles { get; set; }
        public double? HoleDiameter { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Thickness { get; set; }
        public double? Diameter { get; set; }
        public double? DiameterOuter { get; set; }
        public int? LastModifiedUserId { get; set; }
        public string? Location { get; set; }
        public string Uuid { get; set; } = null!;
        public double SurfaceArea { get; set; }
        public double InitialWeight { get; set; }
        public string? ReportSchedule { get; set; }
        public int? LastMeasurementId { get; set; }
        public bool ModbusStoreCrEnabled { get; set; }
        public int? ModbusStoreCrParamsId { get; set; }
        public bool ModbusStoreMlEnabled { get; set; }
        public int? ModbusStoreMlParamsId { get; set; }
        public bool Notify { get; set; }
        public int ReportLastDays { get; set; }
        public string CorrosionRateStatus { get; set; } = null!;
        public double? CorrosionRateThresholdHigh1 { get; set; }
        public double? CorrosionRateThresholdHigh2 { get; set; }
        public double? CorrosionRateThresholdLow1 { get; set; }
        public double? CorrosionRateThresholdLow2 { get; set; }
        public int? ErrorLogId { get; set; }
        public string MetalLossStatus { get; set; } = null!;
        public double? MetalLossThresholdHigh1 { get; set; }
        public double? MetalLossThresholdHigh2 { get; set; }
        public double? MetalLossThresholdLow1 { get; set; }
        public double? MetalLossThresholdLow2 { get; set; }
        public string Status { get; set; } = null!;

        public virtual AssetsErrorlog? ErrorLog { get; set; }
        public virtual AssetsCouponmeasurement? LastMeasurement { get; set; }
        public virtual StaffUser? LastModifiedUser { get; set; }
        public virtual AssetsModbusstoreparameter? ModbusStoreCrParams { get; set; }
        public virtual AssetsModbusstoreparameter? ModbusStoreMlParams { get; set; }
        public virtual ICollection<AssetsCouponmeasurement> AssetsCouponmeasurements { get; set; }
        public virtual ICollection<AssetsCouponstatuschange> AssetsCouponstatuschanges { get; set; }
    }
}
