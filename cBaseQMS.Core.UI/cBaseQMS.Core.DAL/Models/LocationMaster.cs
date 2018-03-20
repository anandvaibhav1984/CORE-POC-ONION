using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class LocationMaster
    {
        public LocationMaster()
        {
            TestMasterMapping = new HashSet<TestMasterMapping>();
        }

        public int LocationMasterId { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? UpdatedTimestamp { get; set; }

        public ICollection<TestMasterMapping> TestMasterMapping { get; set; }
    }
}
