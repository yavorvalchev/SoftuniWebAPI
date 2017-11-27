using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using YavorValchevWebAPI.ExternalService;

namespace YavorValchevWebAPITests
{

    [TestFixture]
    class LINQTests
    {

        [Test]
        public void LINQ()
        {
            var students = GetStudents();
            var courses = GetCourses();
            var studentCourse = from s in students
                                     join c in courses on s.CourseId equals c.Id
                                     select new { s.FullName, CourseName = c.Name };
            var result = "";
            foreach (var sc in studentCourse)
            {
                result += $"{sc.FullName},{sc.CourseName}\n";
            }
        }

        private static List<Course> GetCourses()
        {
            return new List<Course>
            {
                new Course{ Id = 1, Name = "PHP"},
                new Course{ Id = 2, Name = "Java"}
            };
        }

        private List<Student> GetStudents()
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
