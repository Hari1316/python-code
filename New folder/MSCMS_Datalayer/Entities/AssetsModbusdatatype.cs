using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsModbusdatatype
    {
        public AssetsModbusdatatype()
        {
            AssetsModbusstoreparameters = new HashSet<AssetsModbusstoreparameter>();
        }

        public int Id { get; set; }
        public string DataType { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<AssetsModbusstoreparameter> AssetsModbusstoreparameters { get; set; }
    }
}
