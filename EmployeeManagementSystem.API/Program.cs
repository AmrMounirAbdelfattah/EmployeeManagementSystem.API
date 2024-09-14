using EmployeeManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using EmployeeManagementSystem.Application.Validators;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Infrastructure.Repositories;
using EmployeeManagementSystem.Application.Services;
using EmployeeManagementSystem.Application.Mapping;
using EmployeeManagementSystem.Application.Interfaces;

namespace EmployeeManagementSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // 1. Add Controllers and FluentValidation
            builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EmployeeValidator>());

            // 2. Add AutoMapper (assuming you have a mapping profile in your Application layer)
            builder.Services.AddAutoMapper(typeof(EmployeeMappingProfile)); // Or specify the assembly containing profiles

            // 3. Add DbContext for PostgreSQL
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // 4. Add Repositories (Generic Repository)
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // 5. Add Application Services (e.g., EmployeeService)
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            // 6. Add Swagger for API documentation (optional but useful for development)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
