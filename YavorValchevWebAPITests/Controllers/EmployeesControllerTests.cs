using NUnit.Framework;
using YavorValchevWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YavorValchevWebAPI.ExternalService;
using NSubstitute;
using YavorValchevWebAPI.Models;

namespace YavorValchevWebAPI.Controllers.Tests
{
    [TestFixture()]
    public class EmployeesControllerTests
    {

        [Test()]
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

        [Test()]
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

        [Test]
        public void GetEmployeesByDepartment()
        {
            var employees = new List<Employee>
            {
                new Employee{ Id=new Guid("11000000-0000-0000-0000-000000000000"), DepartmentId = new Guid("10000000-0000-0000-0000-000000000000") },
                new Employee{ Id=new Guid("12000000-0000-0000-0000-000000000000"), DepartmentId = new Guid("10000000-0000-0000-0000-000000000000") },
                new Employee{ Id=new Guid("21000000-0000-0000-0000-000000000000"), DepartmentId = new Guid("20000000-0000-0000-0000-000000000000") }
            };
            var employeesController = new EmployeesController();
            var departmentEmployees = employeesController.GetEmployeesByDepartment(employees, new Guid("20000000-0000-0000-0000-000000000000"));
            Assert.AreEqual(1, departmentEmployees.Count());
            Assert.AreSame(employees[2], departmentEmployees.First());
        }
    }
}