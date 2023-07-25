using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class StaffUsernotification
    {
        public int Id { get; set; }
        public bool SendEmail { get; set; }
        public bool SendTextMessage { get; set; }
        public int UserId { get; set; }

        public virtual StaffUser User { get; set; } = null!;
    }
}
