using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSTA.Models
{
    public class Tour
    {
        public int tourRef { get; set; }
        public int numOfDays { get; set; }
        public string destination { get; set; }
        public DateTime departureDate { get; set; }
        public int numOfPassengers { get; set; }
        public Leader tourLeader { get; set; }
    }
}