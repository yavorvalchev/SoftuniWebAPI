using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YavorValchevWebAPI.ExternalService
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}