using System;
using System.Collections.Generic;

namespace EmployeesProject.Models
{
    public partial class EmployeeState
    {
        public int StateId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual State State { get; set; } = null!;
    }
}
