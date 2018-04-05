﻿using System;
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
        public int MemberID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Group")]
        public int GroupID { get; set; }

        public ICollection<TimeCard> TimeCards { get; set; }
    }
}
