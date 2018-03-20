using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class TestAttributes
    {
        public int TestAttrId { get; set; }
        public int TestId { get; set; }
        public short Sequence { get; set; }
        public string Attribute { get; set; }
        public string Value { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Tests Test { get; set; }
    }
}
