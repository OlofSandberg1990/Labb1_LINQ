using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Models
{
    internal class Teacher
    {
        [Key]        
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Course> Courses { get; set; }




    }
}
