using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class InputFieldsValue
    {
        public int InputFieldValueId { get; set; }
        public int InputFieldId { get; set; }
        public int TestCycle { get; set; }
        public decimal? Value { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public InputFields InputField { get; set; }
    }
}
