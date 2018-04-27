using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KLTTimekeeper.Models
{
    public class Course
    {

        [Key]
        public int CourseID { get; set; }
        public int InstructorID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public String CourseName { get; set; }

        public ICollection<CourseMember> CourseMembers { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
