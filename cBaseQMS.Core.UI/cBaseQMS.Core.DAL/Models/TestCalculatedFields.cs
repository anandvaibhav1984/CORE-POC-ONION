using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class TestCalculatedFields
    {
        public int CalcFieldId { get; set; }
        public int TestId { get; set; }
        public byte Sequence { get; set; }
        public string FieldName { get; set; }
        public string Description { get; set; }
        public string Calculation { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Tests Test { get; set; }
    }
}
