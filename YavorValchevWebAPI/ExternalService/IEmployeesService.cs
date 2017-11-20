using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YavorValchevWebAPI.ExternalService
{
    public interface IEmployeesService: IDisposable
    {
        IEnumerable<Employee> GetEmployees();
    }
}