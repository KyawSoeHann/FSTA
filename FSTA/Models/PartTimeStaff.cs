using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSTA.Models;

namespace FSTA.Models
{
    public class PartTimeStaff : Leader
    {
        public int partTimeId { get; set; }
        public int dailyRate { get; set; }
        public string destinationOpted { get; set; }

        public override int getTotalRate(int numberOfDays)
        {
            return dailyRate * numberOfDays;
        }
        public override bool checkDestination(string destination)
        {
            if (destination == destinationOpted)
            return true;
            else
            return false;
        }
    }
}