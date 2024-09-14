using EmployeeManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(EmployeeDto employeeDto);
        Task UpdateEmployeeAsync(int id, EmployeeDto employeeDto);
        Task DeleteEmployeeAsync(int id);
    }
}
