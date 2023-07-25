using System;
using System.Collections.Generic;

namespace MSCMS_Datalayer.Entities
{
    public partial class AssetsMimicdiagram
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
        public string Name { get; set; } = null!;
        public string Diagram { get; set; } = null!;
        public int? LastModifiedUserId { get; set; }

        public virtual StaffUser? LastModifiedUser { get; set; }
    }
}
