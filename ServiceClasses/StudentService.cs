using Labb1_LINQ.Data;
using Labb1_LINQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Labb1_LINQ.ServiceClasses
{
    internal class StudentService
    {
        public static void GetStudents(SchoolDbContext db)
        {
            Console.Clear();
            Console.WriteLine("-----Studenter med sina lärare-----");

            //Skapar en lista med Studenter och deras lärare. Går igenom courses och sen till lärare för att
            //få med lärarna till listan.
            var studentsWithTeachers = db.Students
                .Include(s => s.Course)     //Här hämtas kursinformationen
                    .ThenInclude(c => c.Teachers) // Här hämtas de lärare som har relation till kurserna
                .Select(s => new  //Skapar en anonym typ för att...
                {
                    StudentName = s.StudentName, //....hämta studenternas namn och...
                    Teachers = s.Course.Teachers.Select(t => t.TeacherName).Distinct().ToList() //... Lärarnas. Disctinct för att hämta unika namn.
                }).ToList();

            foreach (var student in studentsWithTeachers)
            {
                Console.Write($"Student: {student.StudentName}");
                Console.Write("\tLärare: ");

                Console.WriteLine(string.Join(", ", student.Teachers)); //Skriver ut lärarna i varje students lista mha string.Join separerat med ett kommatecken.

            }
            Console.WriteLine("\nTryck på enter för att komma tillbaka till menyn");
            Console.ReadKey();
            Console.Clear();
        }

        public static void UpdateStudentRecord(SchoolDbContext db)
        {
            {
                Console.Clear();

                // Laddar alla studenter från databasen, inklusive deras kurser och de lärare som är knutna till dessa kurser.
                var allStudents = db.Students
                    .Include(s => s.Course)
                        .ThenInclude(c => c.Teachers)
                    .ToList();

                Console.WriteLine("Välj en student genom att ange ett nummer");

                
                int studentIndex = 1;
                foreach (var student in allStudents)
                {
                    Console.WriteLine($"{studentIndex}, {student.StudentName}");
                    studentIndex++;
                }

                int chosenStudentIndex = SubjectService.CheckIfInt(1, allStudents.Count) - 1;

                //Sparar en vald student från listan i variabeln selectedStudent
                var selectedStudent = allStudents[chosenStudentIndex];

                //Hämtar den valda studentens kurser
                var studentCourse = selectedStudent.Course;

                Console.WriteLine($"Vilken lärare vill du ta bort från {selectedStudent.StudentName}s kurs?");
                Console.WriteLine("Välj en lärare genom att ange ett nummer");
                                
                int teacherIndex = 1;

                //Skriver ut en lista med den valda studentens lärare
                var teacherList = studentCourse.Teachers.ToList();
                foreach (var teacher in teacherList)
                {
                    Console.WriteLine($"{teacherIndex}, {teacher.TeacherName}");
                    teacherIndex++;
                }

                int teacherToRemoveIndex = SubjectService.CheckIfInt(1, teacherList.Count) - 1;

                //Sparar vilken lärare som ska tas bort och tar sedan bort den från databasen.
                var teacherToRemove = teacherList[teacherToRemoveIndex];

                Console.WriteLine("Vilken lärare vill du lägga till?");
                Console.WriteLine("Välj genom att ange ett nummer");

                
                //Skapar en lista med lärare och skriver sedan ut den med foreach
                var availableTeachers = db.Teachers.ToList();
                int availableTeacherIndex = 1;
                foreach (var teacher in availableTeachers)
                {
                    Console.WriteLine($"{availableTeacherIndex}. {teacher.TeacherName}");
                    availableTeacherIndex++;
                }

                int teacherToAddIndex = SubjectService.CheckIfInt(1, availableTeachers.Count) - 1;
                var teacherToAdd = availableTeachers[teacherToAddIndex];

                // Tar bort den valda läraren från kursen och lägger till en ny.
                studentCourse.Teachers.Add(teacherToAdd);
                studentCourse.Teachers.Remove(teacherToRemove);
                                
                db.SaveChanges();

                Console.WriteLine($"{teacherToRemove.TeacherName} har nu tagits bort och ersatts med {teacherToAdd.TeacherName}");

                Console.WriteLine("\nTryck på enter för att komma tillbaka till menyn");
                Console.ReadKey();
                Console.Clear();
            }

        }

    }
}