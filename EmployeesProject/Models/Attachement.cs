using System;
using System.Collections.Generic;

namespace EmployeesProject.Models
{
    public partial class Attachement
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Size { get; set; }
        public string Type { get; set; } = null!;
        public byte[] Basecode { get; set; } = null!;
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
