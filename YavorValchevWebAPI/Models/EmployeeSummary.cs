using System;

namespace YavorValchevWebAPI.Models
{
    public class EmployeeSummary
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string DepartmentName { get; set; }
    }
}