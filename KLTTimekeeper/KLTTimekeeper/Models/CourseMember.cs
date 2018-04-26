using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KLTTimekeeper.Models
{
    public class CourseMember
    {

        public int CourseMemberID { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserID { get; set; }
        [ForeignKey("COurse")]
        public int CourseID { get; set; }
    }
}
