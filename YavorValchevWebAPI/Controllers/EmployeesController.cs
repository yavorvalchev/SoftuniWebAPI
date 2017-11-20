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

        public IEnumerable<EmployeeSummary> GetEmployees(Guid? departmentId, string city)
        {
            using (var service = new EmployeesService())
            {
                return FilterEmployees(service.GetEmployees(), departmentId, city)
                    ?.Select(employee => ConvertToEmployeeSummary(employee));
            }
        }

        //public IEnumerable<EmployeeSummary> GetEmployees(Guid? departmentId, string city)
        //{
        //    using (IEmployeesService service = new EmployeesService())
        //    {
        //        var employees = service.GetEmployees();
        //        if (departmentId.HasValue)
        //            employees = employees?.Where(employee => employee.DepartmentId == departmentId);
        //        if (!string.IsNullOrEmpty(city))
        //            employees = employees.Where(employee => employee?.Address?.City == city);

        //        return employees?.Select(employee => new EmployeeSummary
        //        {
        //            FullName = (employee.FirstName + " " + employee.LastName).Trim(),
        //            City = employee.Address?.City,
        //            Email = employee.Email,
        //            Id = employee.Id
        //        });
        //    }
        //}

        public IEnumerable<Employee> FilterEmployees(IEnumerable<Employee> employees, Guid? departmentId, string city)
        {
            if(departmentId.HasValue)
                employees = employees?.Where(employee => employee.DepartmentId == departmentId);
            if (!string.IsNullOrEmpty(city))
                employees = employees.Where(employee => employee?.Address?.City == city);
            return employees;
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