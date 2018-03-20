using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class Tests
    {
        public Tests()
        {
            Equations = new HashSet<Equations>();
            PartAttributes = new HashSet<PartAttributes>();
            TestAttributes = new HashSet<TestAttributes>();
            TestCalculatedFields = new HashSet<TestCalculatedFields>();
            TestInputs = new HashSet<TestInputs>();
        }

        public int TestId { get; set; }
        public int TestMasterId { get; set; }
        public string TestName { get; set; }
        public string Descriptions { get; set; }
        public int Sequence { get; set; }
        public string Expression { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsExecuted { get; set; }
        public bool? Result { get; set; }

        public TestMaster TestMaster { get; set; }
        public ICollection<Equations> Equations { get; set; }
        public ICollection<PartAttributes> PartAttributes { get; set; }
        public ICollection<TestAttributes> TestAttributes { get; set; }
        public ICollection<TestCalculatedFields> TestCalculatedFields { get; set; }
        public ICollection<TestInputs> TestInputs { get; set; }
    }
}
