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

        //time project was created and when it is due
        public DateTime dateCreated { get; set; }
        public DateTime dateDue { get; set; }

        ////course the project was created in/for
        //public string course { get; set; }

        //name of the project
        public string projectName { get; set; }

    }
}
