using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YavorValchevWebAPI.ExternalService
{
    public class EmployeesService : IEmployeesService
    {
        public void Dispose()
        {
            
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee{ Id=new Guid("11000000-0000-0000-0000-000000000000"), DepartmentId = new Guid("10000000-0000-0000-0000-000000000000"), Email = "i.georgiev@email.com", FirstName= "Ivan", LastName = "Georgiev", PhoneNumber = "123", Address = new Address{ Country = "Bulgaria", City="Burgas", Street="Morska", Number="12"} },
                new Employee{ Id=new Guid("12000000-0000-0000-0000-000000000000"), DepartmentId = new Guid("10000000-0000-0000-0000-000000000000"), Email = "p.angelov@email.com", FirstName="Peter", LastName="Angelov", PhoneNumber="234", Address = new Address{Country = "Bulgaria", City="Plovdiv", Street="Vasil Levski", Number="3"}},
                new Employee{ Id=new Guid("21000000-0000-0000-0000-000000000000"), DepartmentId = new Guid("20000000-0000-0000-0000-000000000000"), Email = "m.todorov@email.com", FirstName="Michail", LastName="Todorov", PhoneNumber="567", Address = new Address{Country="Bulgaria", City="Pleven", Street="Ivanova mahala", Number="7" } }
            };
        }
    }
}