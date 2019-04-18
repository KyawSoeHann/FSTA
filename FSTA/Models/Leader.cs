using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSTA.Models
{
    public class Leader
    {
        public int id { get; set; }
        public string name { get; set; }
        public string contactNumber { get; set; }
        public string email { get; set; }

        public virtual int getTotalRate(int numberOfDays) {
            return 0;
        }
        public virtual bool checkDestination(string destination)
        {
            return true;
        }
    }
}