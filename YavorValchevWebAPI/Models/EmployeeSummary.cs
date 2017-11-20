using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YavorValchevWebAPI.Models
{
    public class EmployeeSummary
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
    }
}