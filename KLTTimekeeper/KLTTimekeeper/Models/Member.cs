using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KLTTimekeeper.Models
{
    public class Member
    {
        //Two Foreign Keys.
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Group")]
        public int GroupID { get; set; }
    }
}
