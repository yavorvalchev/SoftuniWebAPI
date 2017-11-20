using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using YavorValchevWebAPI;
using YavorValchevWebAPI.ExternalService;
using YavorValchevWebAPI.Models;

namespace YavorValchevWebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        
        public IEnumerable<EmployeeSummary> GetEmployees()
        {
            using (var service = new EmployeesService())
            {
                return service.GetEmployees().Select(employee => ConvertToEmployeeSummary(employee));
            }
        }
        
        public IEnumerable<EmployeeSummary> GetEmployees(Guid departmentId)
        {
            using (var service = new EmployeesService())
            {
                return GetEmployeesByDepartment(service.GetEmployees(), departmentId)
                    ?.Select(employee => ConvertToEmployeeSummary(employee));
            }
        }
        
        public IEnumerable<Employee> GetEmployeesByDepartment(IEnumerable<Employee> employees, Guid departmentId)
        {
            return employees?.Where(employee => employee.DepartmentId == departmentId);
        }

        public EmployeeSummary ConvertToEmployeeSummary(Employee employee)
        {
            return new EmployeeSummary
            {
                FullName = (employee.FirstName + " " + employee.LastName).Trim(),
                City = employee.Address?.City,
                Email = employee.Email,
                Id = employee.Id
            };
        }
    }
}