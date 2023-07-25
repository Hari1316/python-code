using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsAsset
    {
        public AssetsAsset()
        {
            AssetsAssetmeasurements = new HashSet<AssetsAssetmeasurement>();
            AssetsAssetstatuschanges = new HashSet<AssetsAssetstatuschange>();
            AssetsErrorlogs = new HashSet<AssetsErrorlog>();
        }

        public int Id { get; set; }

        [ForeignKey("Uuid")]
        public string Uuid { get; set; } = null!;
        public bool Deleted { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; } = null!;
        public double TemperatureCompDataValue { get; set; }
        public int? DataPollingInterval { get; set; }
        public DateTime? DataPollingIntervalStart { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
        public bool Autopolling { get; set; }
        public DateTime ProbeInstallationDate { get; set; }
        public double? MetalLossThresholdHigh1 { get; set; }
        public double? CorrosionRateThresholdHigh1 { get; set; }
        public int AssetModelId { get; set; }
        public int? DeviceId { get; set; }
        public int LastModifiedUserId { get; set; }
        public int? LiveDataId { get; set; }
        public int? ProbeId { get; set; }
        public int? ProtocolId { get; set; }
        public int? UnitId { get; set; }
        public string? MetalLossFormula { get; set; }
        public bool Notify { get; set; }
        public string? OpcTag { get; set; }
        public string MetalLossUnit { get; set; } = null!;
        public int? ModbusStoreMlParamsId { get; set; }
        public int? ModbusStoreCrParamsId { get; set; }
        public bool ModbusStoreCrEnabled { get; set; }
        public bool ModbusStoreMlEnabled { get; set; }
        public string? ReportSchedule { get; set; }
        public double? CorrosionRateThresholdHigh2 { get; set; }
        public double? CorrosionRateThresholdLow1 { get; set; }
        public double? CorrosionRateThresholdLow2 { get; set; }
        public double? MetalLossThresholdHigh2 { get; set; }
        public double? MetalLossThresholdLow1 { get; set; }
        public double? MetalLossThresholdLow2 { get; set; }        
        public int ReportLastDays { get; set; }
        public int? ProbeLprId { get; set; }

        public virtual AssetsAssetmodel AssetModel { get; set; } = null!;
        public virtual AssetsDevice? Device { get; set; }
        public virtual StaffUser LastModifiedUser { get; set; } = null!;
        public virtual AssetsLivedatum? LiveData { get; set; }
        public virtual AssetsModbusstoreparameter? ModbusStoreCrParams { get; set; }
        public virtual AssetsModbusstoreparameter? ModbusStoreMlParams { get; set; }
        public virtual AssetsProbe? Probe { get; set; }
        public virtual AssetsProbelpr? ProbeLpr { get; set; }
        public virtual AssetsProtocol? Protocol { get; set; }
        public virtual ICollection<AssetsAssetmeasurement> AssetsAssetmeasurements { get; set; }
        public virtual ICollection<AssetsAssetstatuschange> AssetsAssetstatuschanges { get; set; }
        public virtual ICollection<AssetsErrorlog> AssetsErrorlogs { get; set; }
    }
}
