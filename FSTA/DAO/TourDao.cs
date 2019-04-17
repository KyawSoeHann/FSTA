using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FSTA.Models;
using FSTA.DAO;
using System.Diagnostics;

namespace FSTA.DAO
{
    public static class TourDao
    {
        public static List<Tour> getTourList()
        {
            List<Tour> tLists = new List<Tour>();
            string query = @"SELECT t.tourRef,t.numDays,t.destination,departureDate,t.numPassengers,l.name,l.id as leaderId FROM Tour t LEFT JOIN Leader l on t.tourLeaderId = l.id";
            using (SqlConnection connection = new SqlConnection(Database.conString)){
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Tour t = new Tour()
                    {
                        tourRef = (int)sdr["tourRef"],
                        numOfDays = (int)sdr["numDays"],
                        destination = (string)sdr["destination"],
                        departureDate = sdr.GetDateTime(3),
                        numOfPassengers = (int)sdr["numPassengers"]
                    };


                    if (sdr["name"].ToString() != "")
                    {
                        Leader l = new Leader()
                        {
                            id = (int)sdr["leaderId"],
                            name = (string)sdr["name"]
                        };

                        t.tourLeader = l;
                    }
                    

                    tLists.Add(t);
                }

            }

            return tLists;

        }

       
        

    }
}