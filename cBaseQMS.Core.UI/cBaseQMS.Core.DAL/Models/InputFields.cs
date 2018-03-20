using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class InputFields
    {
        public InputFields()
        {
            InputFieldsValue = new HashSet<InputFieldsValue>();
        }

        public int InputFieldId { get; set; }
        public int TestInputId { get; set; }
        public string FieldColumnName { get; set; }
        public int? FieldRowNo { get; set; }
        public string FieldName { get; set; }
        public decimal? CurrentFieldValue { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public int? TestId { get; set; }

        public TestInputs TestInput { get; set; }
        public ICollection<InputFieldsValue> InputFieldsValue { get; set; }
    }
}
