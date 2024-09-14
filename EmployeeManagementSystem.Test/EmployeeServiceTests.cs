using AutoMapper;
using EmployeeManagementSystem.Application.DTOs;
using EmployeeManagementSystem.Application.Services;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementSystem.Test
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IGenericRepository<Employee>> _employeeRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly EmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            _employeeRepositoryMock = new Mock<IGenericRepository<Employee>>();
            _mapperMock = new Mock<IMapper>();
            _employeeService = new EmployeeService(_employeeRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAllEmployeesAsync_ReturnsEmployeeDtos()
        {
            // Arrange
            var employees = new List<Employee> { new Employee { EmployeeID = 1, Name = "Amr" } };
            _employeeRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);

            var employeeDtos = new List<EmployeeDto> { new EmployeeDto { EmployeeID = 1, Name = "Amr" } };
            _mapperMock.Setup(m => m.Map<IEnumerable<EmployeeDto>>(It.IsAny<IEnumerable<Employee>>())).Returns(employeeDtos);

            // Act
            var result = await _employeeService.GetAllEmployeesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("John", result.First().Name);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_EmployeeNotFound_ThrowsException()
        {
            // Arrange
            _employeeRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Employee)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _employeeService.GetEmployeeByIdAsync(1));
        }
    }
}
