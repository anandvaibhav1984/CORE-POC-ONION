﻿using System;
using System.Collections.Generic;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class Equations
    {
        public int EquationId { get; set; }
        public int TestId { get; set; }
        public string EquationName { get; set; }
        public string Description { get; set; }
        public string EquationString { get; set; }
        public string Condition { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Tests Test { get; set; }
    }
}
