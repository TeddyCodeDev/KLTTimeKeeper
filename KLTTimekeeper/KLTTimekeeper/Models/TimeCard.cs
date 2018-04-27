using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KLTTimekeeper.Models
{
    public class TimeCard
    {
        [Key]
        public int TimeCardID { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserID { get; set; }
        [ForeignKey("Group")]
        public int GroupID { get; set; }

        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
        //To get the difference between ClockOut and ClockIn, use ClockOut.Subtract(ClockIn). 
        
    }
}
