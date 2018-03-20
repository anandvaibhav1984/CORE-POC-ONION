using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class TestInputs
    {
        public TestInputs()
        {
            InputFields = new HashSet<InputFields>();
        }

        public int TestInputId { get; set; }
        public int TestId { get; set; }
        public string InputName { get; set; }
        public string Uom { get; set; }
        public string Description { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Sequence { get; set; }
        public byte[] Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public Tests Test { get; set; }
        public ICollection<InputFields> InputFields { get; set; }
    }
}
