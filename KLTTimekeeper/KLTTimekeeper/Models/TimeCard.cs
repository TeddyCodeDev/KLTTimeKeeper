using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KLTTimekeeper.Models
{
    public class TimeCard
    {
        //Primary Key.
        [Key]
        public int TimeCardID { get; set; }
        //Foreign Key
        public int UserID { get; set; }
        public int GroupID { get; set; }

        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
        //To get the difference between ClockOut and ClockIn, use ClockOut.Subtract(ClockIn). 
        
    }
}
