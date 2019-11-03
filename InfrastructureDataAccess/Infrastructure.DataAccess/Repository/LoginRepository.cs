using BusinessDomain.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InfrastructureDataAccess.Infrastructure.DataAccess.Repository
{
    public class LoginRepository : AbstractRepository
    {

        public IEnumerable<Login> Identification(string username, string password)
        {
            List<Login> lg= new List<Login>();


            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = "ps_login_all";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lg.Add(new Login
                            {
                                //Id = Convert.ToInt32(reader["Id"].ToString()),
                                username = reader["username"].ToString(),
                                password = reader["password"].ToString(),


                            });

                        }
                    }
                }

                conn.Close();
            }

            return lg;
        }

    }
}