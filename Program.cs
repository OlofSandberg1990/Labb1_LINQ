using Labb1_LINQ.Data;
using Labb1_LINQ.Models;
using Labb1_LINQ.ServiceClasses;
using Microsoft.EntityFrameworkCore;

namespace Labb1_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Skapar en instans av databasen
            using SchoolDbContext db = new SchoolDbContext();

            //Skapar instanser av de olika objekten och lägger in lite data


            var teacher1 = new Teacher { TeacherName = "Anas" };
            var teacher2 = new Teacher { TeacherName = "Reidar" };
            var teacher3 = new Teacher { TeacherName = "Pär" };
            var teacher4 = new Teacher { TeacherName = "Lena" };
            var teacher5 = new Teacher { TeacherName = "Tobias" };
            //db.Teachers.AddRange(teacher1, teacher2, teacher3, teacher4, teacher5);

            var subject1 = new Subject { SubjectName = "C#", Teachers = new List<Teacher> { teacher1, teacher2 } };
            var subject2 = new Subject { SubjectName = "Matte", Teachers = new List<Teacher> { teacher3, teacher4, teacher5 } };
            var subject3 = new Subject { SubjectName = "Programmering1", Teachers = new List<Teacher> { teacher1, teacher2, teacher3 } };
            var subject4 = new Subject { SubjectName = "Programmering2", Teachers = new List<Teacher> { teacher1, teacher2, teacher4 } };
            //db.Subjects.AddRange(subject1, subject2, subject3, subject4);

            var SUT23 = new Course
            {
                CourseName = "SUT23",
                Teachers = new List<Teacher> { teacher1, teacher3 },
                Subjects = new List<Subject> { subject1, subject3, subject4 }
            };
            var ITP23 = new Course
            {
                CourseName = "ITP23",
                Teachers = new List<Teacher> { teacher4, teacher5 },
                Subjects = new List<Subject> { subject3, subject4 }
            };
            //db.Courses.AddRange(SUT23, ITP23);

            var student1 = new Student { StudentName = "Olof Sandberg", Course = SUT23 };
            var student2 = new Student { StudentName = "Anna Jonsson", Course = SUT23 };
            var student3 = new Student { StudentName = "Erik Lundin", Course = SUT23 };
            var student4 = new Student { StudentName = "Sara Karlsson", Course = SUT23 };
            var student5 = new Student { StudentName = "Lars Magnusson", Course = SUT23 };
            var student6 = new Student { StudentName = "Nina Persson", Course = SUT23 };
            var student7 = new Student { StudentName = "Lina Persson", Course = ITP23 };
            var student8 = new Student { StudentName = "Maja Svensson", Course = ITP23 };
            //db.Students.AddRange(student1, student2, student3, student4, student5, student6, student7, student8);



            //db.SaveChanges();

            bool runProgram = true;

            while (runProgram)
            {
                Console.WriteLine("Välkommen till Skolsystemet");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1, Visa alla mattelärare");
                Console.WriteLine("2, Hämta alla elever med sina lärare");
                Console.WriteLine("3, Kolla om Programmering 1 finns med eller inte");
                Console.WriteLine("4, Byt namn på ett ämne");
                Console.WriteLine("5, Uppdatera student record");
                Console.WriteLine("6, Avsluta");

                //Kontrollerar att input är en int genom metodern CheckIfInt
                int input = SubjectService.CheckIfInt(1, 6);


                switch (input)
                {
                    case 1:
                        TeacherService.GetMathTeachers(db);

                        break;
                    case 2:
                        StudentService.GetStudents(db);

                        break;
                    case 3:
                        SubjectService.CheckSubject(db);

                        break;
                    case 4:
                        SubjectService.ChangeSubjectName(db);

                        break;
                    case 5:

                        StudentService.UpdateStudentRecord(db);

                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Programmet avslutas");
                        Console.ReadKey();
                        runProgram = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Skriv in ett giltligt nummer");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }

            }
        }
    }
}
