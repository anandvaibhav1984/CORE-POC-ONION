using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class PartMaster
    {
        public PartMaster()
        {
            TestMasterMapping = new HashSet<TestMasterMapping>();
        }

        public int PartMasterId { get; set; }
        public string PartNumber { get; set; }
        public string PartDescription { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? UpdatedTimestamp { get; set; }

        public ICollection<TestMasterMapping> TestMasterMapping { get; set; }
    }
}
