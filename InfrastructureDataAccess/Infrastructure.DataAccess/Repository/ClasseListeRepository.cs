using BusinessDomain.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InfrastructureDataAccess.Infrastructure.DataAccess.Repository
{
    public class ClasseListeRepository : AbstractRepository
    {

        public IEnumerable<ClasseListe> GetAllCatListes()
        {
            List<ClasseListe> catListe = new List<ClasseListe>();
            

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = "ps_listesclasses_all";

                using (SqlCommand command = new SqlCommand(sql, conn)) 
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            catListe.Add(new ClasseListe
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                NomClasses = reader["NomClasses"].ToString(),
                                Niveau = Convert.ToInt32(reader["Niveau"].ToString()),
                                Images = reader["Images"].ToString(),
                               
                            });
                          
                        }
                    }
                }

                conn.Close();
            }

            return catListe;
        }

    

        public ClasseListe GetClasseListeById(int idCatListe)
        {
            ClasseListe classe = new ClasseListe();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("ps_listesclasses_select_by_id", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", idCatListe);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            classe.Id = Convert.ToInt32(reader["Id"].ToString());
                            classe.NomClasses = reader["NomClasses"].ToString();
                            classe.Niveau = Convert.ToInt32(reader["Niveau"].ToString());
                            classe.Images = reader["Images"].ToString();
                        }

                        reader.Close();
                    }

                    command.ExecuteNonQuery();
                }

                conn.Close();
            }

            return classe;
        }

    }
}