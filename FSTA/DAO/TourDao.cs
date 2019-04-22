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
            using (SqlConnection connection = new SqlConnection(Database.conString)) {
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

        public static Tour getTourById(int tourRef)
        {
            Tour t = new Tour();
            string query = @"SELECT t.tourRef,t.numDays,t.destination,departureDate,t.numPassengers,l.name,l.id as leaderId FROM Tour t LEFT JOIN Leader l on t.tourLeaderId = l.id where t.tourRef =" + tourRef;

            using (SqlConnection connection = new SqlConnection(Database.conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@tourRef";
                param.Value = tourRef;
                cmd.Parameters.Add(param);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    t.tourRef = (int)sdr["tourRef"];
                    t.numOfDays = (int)sdr["numDays"];
                    t.destination = (string)sdr["destination"];
                    t.departureDate = sdr.GetDateTime(3);
                    t.numOfPassengers = (int)sdr["numPassengers"];



                    if (sdr["name"].ToString() != "")
                    {
                        Leader l = new Leader()
                        {
                            id = (int)sdr["leaderId"],
                            name = (string)sdr["name"]
                        };

                        t.tourLeader = l;


                    }
                }
            }
            return t;
        }
        public static void UpdateLeader(int leaderId, int tourRef)
        {
            string query = @"UPDATE TOUR SET tourLeaderId = " + leaderId + " WHERE tourRef =" + tourRef;
            using (SqlConnection connection = new SqlConnection(Database.conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        public static List<Tour> getToursByLeaderId(int leaderId)
        {
            List<Tour> assignments = new List<Tour>();
            string query = @"SELECT t.numDays,departureDate FROM Tour t LEFT JOIN Leader l on t.tourLeaderId = l.id where t.tourLeaderId = @leaderId";
            using (SqlConnection connection = new SqlConnection(Database.conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@leaderId";
                param.Value = leaderId;
                cmd.Parameters.Add(param);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Tour task = new Tour()
                    {
                        numOfDays = (int)sdr["numDays"],
                        departureDate = sdr.GetDateTime(1)
                    };
                    assignments.Add(task);
                }
            }
            return assignments;
        }
    }
}

