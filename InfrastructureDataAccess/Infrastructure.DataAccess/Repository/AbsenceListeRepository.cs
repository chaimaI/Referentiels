using BusinessDomain.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InfrastructureDataAccess.Infrastructure.DataAccess.Repository
{
    public class AbsenceListeRepository : AbstractRepository
    {

        public IEnumerable<ItemListe> GetAllItemListByList(int idList)
        {
            List<ItemListe> itemList = new List<ItemListe>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("ps_absences_by_classeid", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdListe", idList);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new ItemListe();
                            item.Id = Convert.ToInt32(reader["Id"].ToString());
                            item.Date = !string.IsNullOrWhiteSpace(reader["Date"].ToString()) ?
                                                    Convert.ToDateTime(reader["Date"]) : default(DateTime);
                            item.Horaires = reader["Horaires"].ToString();
                            item.Nom = reader["Nom"].ToString();
                            item.Prenom = reader["Prenom"].ToString();
                            item.Presences = reader["Presences"].ToString();
                            item.Commentaires = reader["Commentaires"].ToString();
                            item.IdClasses = Convert.ToInt32(reader["IdClasses"].ToString());


                            itemList.Add(item);
                        }

                        reader.Close();
                    }

                    command.ExecuteNonQuery();
                }

                conn.Close();
            }

            return itemList;
        }



        public ItemListe GetItemListById(int idItemList)
        {
            ItemListe item = new ItemListe();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("ps_absences_by_id", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", idItemList);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item.Id = Convert.ToInt32(reader["Id"].ToString());
                            item.Date = !string.IsNullOrWhiteSpace(reader["Date"].ToString()) ?
                                                    Convert.ToDateTime(reader["Date"]) : default(DateTime);
                            item.Horaires = reader["Horaires"].ToString();
                            item.Nom = reader["Nom"].ToString();
                            item.Prenom = reader["Prenom"].ToString();
                            item.Presences = reader["Presences"].ToString();
                            item.Commentaires = reader["Commentaires"].ToString();
                            item.IdClasses = Convert.ToInt32(reader["IdClasses"].ToString());
                        }

                        reader.Close();
                    }

                    command.ExecuteNonQuery();
                }

                conn.Close();
            }

            return item;
        }

    

        public int CreateAbsenceListe(DateTime date, string horaires, string nom, string prenom, string presences, string commentaires, int idClasses)
        {
            int returnId;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = "[dbo].[ps_absences_insert]";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Horaires", horaires);
                    command.Parameters.AddWithValue("@Nom", nom);
                    command.Parameters.AddWithValue("@Prenom", prenom);
                    command.Parameters.AddWithValue("@Presences", presences);
                    command.Parameters.AddWithValue("@Commentaires", commentaires);
                    command.Parameters.AddWithValue("@IdClasses", idClasses);
                    SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputIdParam);

                    command.ExecuteNonQuery();
                    returnId = Convert.ToInt32(command.Parameters["@Id"].Value.ToString());
                }

                conn.Close();
            }

            return returnId;
        }


        public void UpdateAbsenceListe(int Id, DateTime date, string horaires, string nom, string prenom, string presences, string commentaires, int idClasses)
        {

       

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = "[dbo].[ps_absence_update]";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = Id;

                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Horaires", horaires);
                    command.Parameters.AddWithValue("@Nom", nom);
                    command.Parameters.AddWithValue("@Prenom", prenom);
                    command.Parameters.AddWithValue("@Presences", presences);
                    command.Parameters.AddWithValue("@Commentaires", commentaires);
                    command.Parameters.AddWithValue("@IdClasses", idClasses);
            

                    command.ExecuteNonQuery();

                }

                conn.Close();
            }

     
        }



    }
}