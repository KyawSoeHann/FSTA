using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSTA.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FSTA.DAO
{
    public static class LeaderDao
    {
        public static List<Leader> getAllLeaders() {
            List<Leader> leaders = new List<Leader>();

            string query = @"select * from Leader l left join PartTime p ON l.id = p.leaderId left join FullTime f on l.id = f.leaderId";

            using(SqlConnection connection = new SqlConnection(Database.conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    if (sdr["fullId"].ToString() == "")
                    {
                        PartTimeStaff pS = new PartTimeStaff()
                        {
                            id = (int)sdr["id"],
                            name = (string)sdr["name"],
                        };

                        leaders.Add(pS);
                    }else
                    {
                        
                        FullTimeStaff fS = new FullTimeStaff()
                        {
                            id = (int) sdr["id"],
                            name = (string)sdr["name"],
                        };
                        leaders.Add(fS);
                    }
                }
            }

            return leaders;
        }

        public static Leader getLeaderById(int leaderId)
        {
            Leader l = null;
            string query = @"select * from Leader l left join PartTime p ON l.id = p.leaderId left join FullTime f on l.id = f.leaderId where l.id = @leaderId";

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
                    if (sdr["fullId"].ToString() == "")
                    {
                        l = new PartTimeStaff()
                        {
                            id = (int)sdr["id"],
                            name = (string)sdr["name"],
                            dailyRate = (int)sdr["dailyRate"]
                        };

                    }
                    else
                    {

                        l = new FullTimeStaff()
                        {
                            id = (int)sdr["id"],
                            name = (string)sdr["name"],
                            staffRank = (string)sdr["staffRank"]
                        };
                    }
                }
            }

            return l;

        }
    }
}