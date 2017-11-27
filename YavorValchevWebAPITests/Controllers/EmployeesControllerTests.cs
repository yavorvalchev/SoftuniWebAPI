using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using YavorValchevWebAPI.ExternalService;

namespace YavorValchevWebAPI.Controllers.Tests
{
    [TestFixture()]
    public class EmployeesControllerTests
    {

        //[Test()]
        public void ConvertToEmployeeSummary_FillsFullName()
        {
            var employee = new Employee
            {
                FirstName = "Ivan",
                LastName = "Georgiev",
            };
            var employeesController = new EmployeesController();
            var actual = employeesController.ConvertToEmployeeSummary(employee);
            Assert.AreEqual("Ivan Georgiev", actual.FullName);
        }

        //[Test()]
        public void ConvertToEmployeeSummary_FillsFullName_IfOnlyFirstName()
        {
            var employee = new Employee
            {
                FirstName = "Ivan",
            };
            var employeesController = new EmployeesController();
            var actual = employeesController.ConvertToEmployeeSummary(employee);
            Assert.AreEqual("Ivan", actual.FullName);
        }

        //[Test]
        public void FilterEmployees_FiltersByDepartment()
        {
            var employees = new List<Employee>
            {
                new Employee{ Id=new Guid("11000000-0000-0000-0000-000000000000"),
                    DepartmentId = new Guid("10000000-0000-0000-0000-000000000000") },
                new Employee{ Id=new Guid("12000000-0000-0000-0000-000000000000"),
                    DepartmentId = new Guid("10000000-0000-0000-0000-000000000000") },
                new Employee{ Id=new Guid("21000000-0000-0000-0000-000000000000"),
                    DepartmentId = new Guid("20000000-0000-0000-0000-000000000000") }
            };
            var employeesController = new EmployeesController();
            var departmentEmployees = employeesController.FilterEmployees(employees, 
                new Guid("20000000-0000-0000-0000-000000000000"), null);
            Assert.AreEqual(1, departmentEmployees.Count());
            Assert.AreSame(employees[2], departmentEmployees.First());
        }

        //[Test]
        public void FilterEmployees_FiltersByCity()
        {

            var employees = new List<Employee>
            {
                new Employee{ Id=new Guid("11000000-0000-0000-0000-000000000000"),
                    Address = new Address{ City="Sofia" } },
                new Employee{ Id=new Guid("12000000-0000-0000-0000-000000000000"),
                    Address = new Address{ City="Sofia" } },
                new Employee{ Id=new Guid("21000000-0000-0000-0000-000000000000"),
                    Address = new Address{ City="Plovdiv" } }
            };
            var employeesController = new EmployeesController();
            var departmentEmployees = employeesController.FilterEmployees(employees, null, "Plovdiv");
            Assert.AreEqual(1, departmentEmployees.Count());
            Assert.AreSame(employees[2], departmentEmployees.First());
        }

    }
}