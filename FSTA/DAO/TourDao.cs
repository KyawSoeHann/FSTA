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

        public static Tour getTourById(int tourRef)
        {
            Tour t = new Tour();
            string query = @"SELECT t.tourRef,t.numDays,t.destination,departureDate,t.numPassengers,l.name,l.id as leaderId FROM Tour t LEFT JOIN Leader l on t.tourLeaderId = l.id where t.tourRef ="+tourRef;

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
            string query = @"UPDATE TOUR SET tourLeaderId = @leaderId WHERE tourRef = @tourRef";
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@leaderId";
            param.Value = leaderId;
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@tourRef";
            param2.Value = tourRef;
            using (SqlConnection connection = new SqlConnection(Database.conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(param2);
                cmd.ExecuteNonQuery();
            }
        }

    }
}