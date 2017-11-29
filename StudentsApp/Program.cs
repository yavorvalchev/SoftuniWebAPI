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
            //Foreach way
            Console.WriteLine("Foreach way");
            Filter_AverageScore_Foreach();
            Console.ReadKey();
            //LINQ way
            Console.WriteLine("LINQ way");
            Filter_AverageScore_LINQ();
            Console.ReadKey();
            //Composability
            Console.WriteLine("Composability");
            StudentsFilter_Composability();
            Console.ReadKey();
            //Query syntax
            Console.WriteLine("Query Syntax");
            //Filter by name
            //Join
            StudentName_CourseName_LINQ();
            Console.ReadKey();
        }

        public static void StudentName_CourseName_LINQ()
        {
            var students = GetStudents();
            var courses = GetCourses();
            var studentCourse = from s in students
                                join m in courses on s.CourseId equals m.Id
                                select new { s.FullName, CourseName = m.Name };
            foreach (var sc in studentCourse)
            {
                Console.WriteLine($"{sc.FullName},{sc.CourseName}");
            }
        }
        
        public static void Filter_AverageScore_Foreach()
        {
            var students = GetStudents();
            foreach (var student in students)
            {
                int sumScores = 0, countScores = 0;
                foreach (var score in student.Scores)
                {
                    sumScores += score;
                    countScores++;
                }
                if (countScores > 0 && sumScores / countScores >= 5)
                    Console.WriteLine(student.FullName);
            }
        }

        public static void Filter_AverageScore_LINQ()
        {
            var students = GetStudents();
            foreach (var student in students.Where(s=>s.Scores.Average() >= 5))
            {
                Console.WriteLine(student.FullName);
            }
        }


        public static void StudentsFilter_Composability()
        {
            var students = GetStudents();
            var courses = GetCourses();

            foreach (var student in students)
            {
                student.Course = courses.Single(m => m.Id == student.CourseId);
            }
            string name = "M";
            int? minAverageScore = 4;

            var studentsQuery = students.AsQueryable();
            if (!string.IsNullOrEmpty(name))
                studentsQuery = studentsQuery.Where(s => s.FullName.StartsWith(name));
            if (minAverageScore.HasValue)
                studentsQuery = studentsQuery.Where(s => s.Scores.Average() > minAverageScore.Value);
            foreach (var student in studentsQuery)
            {
                Console.WriteLine(student.FullName);
            }
        }

        private static List<Course> GetCourses()
        {
            return new List<Course>
            {
                new Course{ Id = 1, Name = "Marketing"},
                new Course{ Id = 2, Name = "Architecture"}
            };
        }

        private static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student{FullName = "Ivan", CourseId = 1, Scores = new List<int>{ 2, 3, 4, 5, 6 } },
                new Student{FullName = "Peter", CourseId = 1, Scores = new List<int>{5, 6, 5, 6, 6 } },
                new Student{FullName = "Georgy", CourseId = 2, Scores = new List<int>{4, 6, 3, 6, 5 } }
            };
        }
    }
}
