using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class TestMaster
    {
        public TestMaster()
        {
            TestMasterMapping = new HashSet<TestMasterMapping>();
            Tests = new HashSet<Tests>();
        }

        public int TestMasterId { get; set; }
        public string TestMasterName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<TestMasterMapping> TestMasterMapping { get; set; }
        public ICollection<Tests> Tests { get; set; }
    }
}
