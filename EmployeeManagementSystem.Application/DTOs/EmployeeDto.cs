using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Application.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public decimal Salary { get; set; }
    }
}
