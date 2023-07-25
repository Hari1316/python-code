using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsSerialport
    {
        public int Id { get; set; }
        public string Ports { get; set; } = null!;
    }
}
