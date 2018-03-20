using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class LocationAttribtes
    {
        public int LocAttrId { get; set; }
        public int MasterLocationId { get; set; }
        public string LocAttrName { get; set; }
        public decimal? Value { get; set; }
        public int? Uomid { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
