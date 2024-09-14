using EmployeeManagementSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Application.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MaximumLength(100);
            RuleFor(e => e.Department).NotEmpty().MaximumLength(100);
            RuleFor(e => e.Salary).GreaterThan(0);
        }
    }
}
