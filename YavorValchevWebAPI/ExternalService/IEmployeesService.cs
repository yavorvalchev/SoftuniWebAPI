using System;
using System.Collections.Generic;

namespace YavorValchevWebAPI.ExternalService
{
    public interface IEmployeesService: IDisposable
    {
        IEnumerable<Employee> GetEmployees();
    }
}