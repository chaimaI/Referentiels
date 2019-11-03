using BusinessDomain.Business.Domain.Models.Monitoring;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static BusinessDomain.Business.Domain.Models.Monitoring.Connector;

namespace InfrastructureDataAccess.Infrastructure.DataAccess.Repository.Monitoring
{
    public class QueryRepository: AbstractRepository
    {
        private readonly string _connect;

        internal const string ConnectionDatabase = "BDD_Interface";

        internal const string UnexpectedError = "Erreur Innatendue";

        public QueryRepository()
        {
            _connect = System.Configuration.ConfigurationManager.ConnectionStrings[ConnectionDatabase].ConnectionString;
        }

        public List<Query> GetQueryAvailable()
        {
            List<Query> listResult = new List<Query>();

            string sql = "Select * from mon_query where active=1";

            using (SqlConnection conn = new SqlConnection(_connect))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Query q = new Query();
                                q.IdQuery = Int32.Parse(reader["IdQuery"].ToString());
                                q.IdQueryConnector = Int32.Parse(reader["IdConnector"].ToString());
                                q.Name = reader["Name"].ToString();
                                q.SqlQuery = reader["SqlQuery"].ToString();
                                q.GreenValue = Int32.Parse(string.IsNullOrEmpty(reader["GreenValue"].ToString()) ? "-1" : reader["GreenValue"].ToString());
                                q.GreenSign = reader["GreenSign"].ToString();
                                q.OrangeValue = Int32.Parse(string.IsNullOrEmpty(reader["OrangeValue"].ToString()) ? "-1" : reader["OrangeValue"].ToString());
                                q.OrangeSign = reader["OrangeSign"].ToString();
                                q.RedValue = Int32.Parse(string.IsNullOrEmpty(reader["RedValue"].ToString()) ? "-1" : reader["RedValue"].ToString());
                                q.RedSign = reader["RedSign"].ToString();
                                q.Description = reader["Description"].ToString();
                                q.IsTechnical = bool.Parse(reader["IsTechnical"].ToString());
                                listResult.Add(q);
                            }
                        }
                    }
                }
            }

            //init parameter, connecteur et filtres

            SetConnectorOfQueries(listResult); // initialise ResultQuery


            return listResult;
        }

        public void SetConnectorOfQueries(List<Query> listQueries)
        {
            string sql = "Select * from mon_query_connector";

            List<Connector> listConnector = new List<Connector>();
            using (SqlConnection conn = new SqlConnection(_connect))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Connector c = new Connector();
                                c.IdConnector = Int32.Parse(reader["IdQueryConnector"].ToString());
                                c.NameConnector = reader["NameConnector"].ToString();
                                c.ValueConnector = reader["ValueConnector"].ToString();
                                c.TypeConnector = Connector.FindConnector(reader["TypeConnector"].ToString());
                                listConnector.Add(c);
                            }
                        }
                    }
                }
            }

            foreach (Query q in listQueries)
            {
                q.QueryConnector = listConnector.Where(x => x.IdConnector == q.IdQueryConnector).FirstOrDefault();
                q.ResultQuery = new ResultQuery(q.QueryConnector.TypeConnector);//init resultquery
            }
        }


        public void ExecuteQuery(Query q)
        {
            switch (q.QueryConnector.TypeConnector)
            {
                case TypeConnectorQuery.sql:
                    ExecuteSQlQuery(q);
                    break;

            }

            SetAlertStatus(q);
        }

        private void ExecuteSQlQuery(Query q)
        {
            try
            {
                //ApplyQueryParameters(q);

                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(q.QueryConnector.ValueConnector))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(q.SqlQuery, conn))
                    {
                        //foreach (QueryParameters param in q.Parameters)
                        //{
                        //    command.Parameters.AddWithValue(param.ParameterName, param.ValueParameter);
                        //}

                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);
                        //if (q.QueryFilters != null && q.QueryFilters.Any())
                        //{
                        //    foreach (QueryFilter qf in q.QueryFilters)
                        //    {
                        //        dt = ApplyFilter(dt, qf);
                        //    }
                        //}
                    }
                }
                q.ResultQuery.ListResultatSql = dt;
            }
            catch (Exception ex)
            {
                q.ErrorMessage = UnexpectedError;
                q.Exception = ex;
                q.StatusAlert = StatusAlert.GetRedAlert();
            }
        }


        private void SetAlertStatus(Query q)
        {
            int nbElement = 0;
            if (string.IsNullOrEmpty(q.StatusAlert.ClassAlert)) //Gestion des exceptions
            {
                
                    nbElement = q.ResultQuery.NbElement;

                    if (TestValueSign(q.GreenSign, q.GreenValue, nbElement))
                    {
                        q.StatusAlert = StatusAlert.GetGreenAlert();
                        return; // exit
                    }

                    if (TestValueSign(q.RedSign, q.RedValue, nbElement))
                    {
                        q.StatusAlert = StatusAlert.GetRedAlert();
                        return; // exit
                    }

                    if (TestValueSign(q.OrangeSign, q.OrangeValue, nbElement))
                    {
                        q.StatusAlert = StatusAlert.GetOrangeAlert();
                        return; // exit
                    }
                
            }
        }

        private bool TestValueSign(string sign, int value, int toCompare)
        {
            switch (sign.Trim())
            {
                case "=":
                    return toCompare == value;

                case ">":
                    return toCompare > value;

                case "<":
                    return toCompare < value;
            }

            return false;
        }



    }
}