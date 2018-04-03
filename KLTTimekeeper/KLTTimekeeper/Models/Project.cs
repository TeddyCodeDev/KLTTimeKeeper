using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KLTTimekeeper.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
