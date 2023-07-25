using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsDevice
    {
        public AssetsDevice()
        {
            AssetsAssets = new HashSet<AssetsAsset>();
        }

        public int Id { get; set; }
        public string? Host { get; set; }
        public int? Port { get; set; }
        public string? SerialPort { get; set; }
        public int? Baudrate { get; set; }
        public int? Databits { get; set; }
        public int? Stopbits { get; set; }
        public string? Parity { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
        public int LastModifiedUserId { get; set; }
        public int ProtocolId { get; set; }
        public int ResponseTimeout { get; set; }
        public bool Dsrdtr { get; set; }
        public bool Rtscts { get; set; }
        public bool Xonxoff { get; set; }

        public virtual StaffUser LastModifiedUser { get; set; } = null!;
        public virtual AssetsProtocol Protocol { get; set; } = null!;
        public virtual ICollection<AssetsAsset> AssetsAssets { get; set; }
    }
}
