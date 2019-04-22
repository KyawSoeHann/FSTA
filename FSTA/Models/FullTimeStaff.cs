using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSTA.Models;

namespace FSTA.Models
{
    public class FullTimeStaff : Leader
    {
        public int staffId { get; set; }
        public int salary { get; set; }
        public int leaveEntitled { get; set; }
        public string staffRank { get; set; }

        public override int getRate()
        {
            int rate = 0;
            switch (staffRank)
            {
                case "M1": rate = 500;
                    break;

                case "M2": rate = 400;
                    break;

                case "M3": rate = 300;
                    break;
            }

            return rate;
        }
    }
}