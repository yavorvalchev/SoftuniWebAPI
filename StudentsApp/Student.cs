using System.Collections.Generic;

namespace StudentsApp
{
    public class Student
    {
        public int MastersId { get; set; }
        public string FullName { get; set; }
        public MastersDegree MastersDegree { get; set; }
        public List<int> Scores { get; set; }
    }
}