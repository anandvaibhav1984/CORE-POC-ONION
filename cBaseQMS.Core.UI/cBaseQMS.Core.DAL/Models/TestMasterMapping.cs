using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class TestMasterMapping
    {
        public int TestMasterMapId { get; set; }
        public int TestMasterId { get; set; }
        public int PartMasterId { get; set; }
        public int LocationMasterId { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public LocationMaster LocationMaster { get; set; }
        public PartMaster PartMaster { get; set; }
        public TestMaster TestMaster { get; set; }
    }
}
