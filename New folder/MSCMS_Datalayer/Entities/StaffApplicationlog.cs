using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class StaffApplicationlog
    {
        public int Id { get; set; }
        public int? Response { get; set; }
        public string? Method { get; set; } = null!;
        public string? Path { get; set; } = null!;
        public DateTime Time { get; set; }
        public string? Ip { get; set; } = null!;
        public string? Body { get; set; }
        public string? QueryParams { get; set; }
        public int? UserId { get; set; }

        public virtual StaffUser? User { get; set; }
    }
}
