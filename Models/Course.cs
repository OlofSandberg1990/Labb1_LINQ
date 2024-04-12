using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Models
{
    internal class Course
    {
        [Key]
        public int Id { get; set; }
        public string CourseName { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
