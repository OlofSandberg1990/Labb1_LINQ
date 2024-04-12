using Labb1_LINQ.Data;
using Labb1_LINQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.ServiceClasses
{
    internal class TeacherService
    {
        public static void GetMathTeachers(SchoolDbContext db)
        {
            Console.Clear();

            //Går igenom varje Teachers subject och kollar om "Matte" finns med som subject name
            var mathTeachers = db.Teachers
                .Where(t => t.Subjects
                    .Any(s => s.SubjectName == "Matte"))
                .ToList();

            Console.WriteLine("-----Följande lärare undervisar i Matte-----");
            foreach (var teacher in mathTeachers)
            {
                Console.WriteLine(teacher.TeacherName);
            }
            Console.WriteLine("\nTryck på enter för att komma tillbaka till menyn");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
