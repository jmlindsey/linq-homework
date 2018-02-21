using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new List<Course>
            {
                new Course {Id = 1, Name = "Calculus", Credits = 3 },
                new Course {Id = 2, Name = "Physics", Credits = 4 },
                new Course {Id = 3, Name = "Psychology", Credits = 1 },
                new Course {Id = 4, Name = "Underwater Basketweaving", Credits = 0 },
            };

            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Alice",
                    Age = 20,
                    EnrolledCourseId = 3
                },
                new Student
                {
                    Id = 2,
                    Name = "Bob",
                    Age = 23,
                    EnrolledCourseId = 1
                },
                new Student
                {
                    Id = 3,
                    Name = "Charlie",
                    Age = 19,
                    EnrolledCourseId = 2
                },
                new Student
                {
                    Id = 4,
                    Name = "Diane",
                    Age = 20,
                    EnrolledCourseId = 4
                },
                new Student
                {
                    Id = 5,
                    Name = "Elliot",
                    Age = 21,
                    EnrolledCourseId = 1
                },
                new Student
                {
                    Id = 6,
                    Name = "Frank",
                    Age = 18,
                    EnrolledCourseId = 3
                },
            };

            /*************************************************************
             * YOUR CODE GOES BELOW HERE                                 *
             *************************************************************/
            void print<T>(IEnumerable<T> things)
            {
                foreach (T thing in things)
                    Console.Write(thing + " ");
                Console.WriteLine();
            }

            //1
            print(students.Select(x => x.Name));
           
            //2
            var prob2res = students.Select(x => x.Name);
            students.Add(new Student { Id = 10, Name = "Brenda", Age = 44, EnrolledCourseId = 1 });
            print(prob2res);

            //3
            var prob3res = prob2res.ToList();
            print(prob3res);

            //4
            Console.WriteLine(students.Count(x => x.EnrolledCourseId == 3));

            //5
            print(students.Where(x => x.Age >= 21).Select(x => x.Name));

            //6
            print(courses.Where(x => x.Credits >= 2).Select(x => x.Name));

            //7
            Console.WriteLine(students.Average(x => x.Age));

            //8
            Console.WriteLine(students.Where(x => x.EnrolledCourseId == 1).Average(x => x.Age));

            //9
            Console.WriteLine(students.OrderByDescending(x => x.Age).First().Name);
            print(students.OrderByDescending(x => x.Age).Take(3).Select(x => x.Name));

            //10
            var students2 = students.Join (courses, (Student s) => s.EnrolledCourseId, (Course c) => c.Id, (s, c) => new EnrolledStudent(s, c));
            print(students2.Select((s) => s.StudentName));
            print(students2.Select((s) => s.CourseName));
            /*************************************************************
             * YOUR CODE GOES ABOVE HERE                                 *
             *************************************************************/

            Console.ReadKey(true);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public int EnrolledCourseId { get; set; }
    }

    class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
    }

    class EnrolledStudent
    {
        public EnrolledStudent(Student s, Course c)
        {
            StudentId = s.Id;
            StudentAge = s.Age;
            StudentName = s.Name;
            CourseName = c.Name;
            Credits = c.Credits;
        }

        public int StudentId { get; set; }
        public int StudentAge { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
    }

}