using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class SystemWebsocketlogging
    {
        public int Id { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string Message { get; set; } = null!;
    }
}
