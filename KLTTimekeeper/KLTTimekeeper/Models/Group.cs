using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KLTTimekeeper.Models
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }
        //[ForeignKey("Project")]
        public int ProjectID { get; set; }
        public Project Project { get; set; }
        public string GroupName { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}
