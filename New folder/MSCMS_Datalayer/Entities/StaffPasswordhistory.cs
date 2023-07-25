using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class StaffPasswordhistory
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
    }
}
