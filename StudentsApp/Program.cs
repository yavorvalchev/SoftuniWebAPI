using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentName_CourseName_Foreach();
            StudentName_CourseName_LINQ();
            Console.ReadKey();
        }

        public static void StudentName_CourseName_LINQ()
        {
            var students = GetStudents();
            var courses = GetCourses();
            var studentCourse = from s in students
                                join c in courses on s.CourseId equals c.Id
                                select new { s.FullName, CourseName = c.Name };
            foreach (var sc in studentCourse)
            {
                Console.WriteLine($"{sc.FullName},{sc.CourseName}");
            }
        }

        public static void StudentName_CourseName_Foreach()
        {
            var students = GetStudents();
            var courses = GetCourses();
            foreach (var student in students)
            {
                foreach (var course in courses)
                {
                    if (course.Id == student.CourseId)
                    {
                        Console.WriteLine($"{student.FullName},{course.Name}");
                    }
                }
            }
        }

        public static void StudentsFilter()
        {
            var students = GetStudents();

        }

        private static List<Course> GetCourses()
        {
            return new List<Course>
            {
                new Course{ Id = 1, Name = "PHP"},
                new Course{ Id = 2, Name = "Java"}
            };
        }

        private static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student{FullName = "Ivan PHP", CourseId = 1},
                new Student{FullName = "Peter PHP", CourseId = 1},
                new Student{FullName = "Georgy Java", CourseId = 2}
            };
        }
    }
}
