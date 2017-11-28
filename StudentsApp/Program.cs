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
            //Filter by name
            StudentsFilter_ByName("I");
            Console.ReadKey();
            //join
            StudentName_MastersName_Foreach();
            StudentName_MastersName_LINQ();
            Console.ReadKey();
            //Filter students by score with LINQ

            StudentsFilter_DepartmentAndAverageScore();
            Console.ReadKey();
        }

        public static void StudentName_MastersName_LINQ()
        {
            var students = GetStudents();
            var masters = GetMasters();
            var studentCourse = from s in students
                                join m in masters on s.MastersId equals m.Id
                                select new { s.FullName, CourseName = m.Name };
            foreach (var sc in studentCourse)
            {
                Console.WriteLine($"{sc.FullName},{sc.CourseName}");
            }
        }

        public static void StudentName_MastersName_Foreach()
        {
            var students = GetStudents();
            var courses = GetMasters();
            foreach (var student in students)
            {
                foreach (var course in courses)
                {
                    if (course.Id == student.MastersId)
                    {
                        Console.WriteLine($"{student.FullName},{course.Name}");
                    }
                }
            }
        }

        public static void StudentsFilter_ByName(string letter)
        {
            var students = GetStudents();
            
            var filteredStudents = from s in students
                                   where s.FullName.StartsWith(letter)
                                   select s;
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student.FullName);
            }
        }

        public static void StudentsFilter_DepartmentAndAverageScore()
        {
            var students = GetStudents();
            var masters = GetMasters();
            foreach (var student in students)
            {
                student.MastersDegree = masters.Single(m => m.Id == student.MastersId);
            }

            foreach (var student in students.Where(s=>s.Scores.Average() > 4 && s.MastersDegree.Name.StartsWith("M")))
            {
                Console.WriteLine("Student:{0}, Masters:{1}", student.FullName, student.MastersDegree.Name);
            }
        }

        private static List<MastersDegree> GetMasters()
        {
            return new List<MastersDegree>
            {
                new MastersDegree{ Id = 1, Name = "Marketing"},
                new MastersDegree{ Id = 2, Name = "Architecture"}
            };
        }

        private static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student{FullName = "Ivan", MastersId = 1, Scores = new List<int>{ 2, 3, 4, 5, 6 } },
                new Student{FullName = "Peter", MastersId = 1, Scores = new List<int>{5, 6, 5, 6, 6 } },
                new Student{FullName = "Georgy", MastersId = 2, Scores = new List<int>{4, 6, 3, 6, 5 } }
            };
        }
    }
}
