using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Models
{
    internal class Student
    {
        [Key] 
        public int Id { get; set; }
        public string StudentName { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }



    }
}
