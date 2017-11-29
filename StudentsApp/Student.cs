using System.Collections.Generic;

namespace StudentsApp
{
    public class Student
    {
        public int CourseId { get; set; }
        public string FullName { get; set; }
        public Course Course { get; set; }
        public List<int> Scores { get; set; }
    }
}