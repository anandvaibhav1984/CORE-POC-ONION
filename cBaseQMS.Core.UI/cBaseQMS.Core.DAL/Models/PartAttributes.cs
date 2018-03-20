using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class PartAttributes
    {
        public int PartAttrId { get; set; }
        public string PartAttrName { get; set; }
        public int PartMasterId { get; set; }
        public int TestId { get; set; }
        public int InputFieldId { get; set; }
        public decimal MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public int? Uomid { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Tests Test { get; set; }
    }
}
