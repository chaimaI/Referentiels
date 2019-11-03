using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessDomain.Business.Domain.Models.Monitoring
{
    public class Connector
    {
        public enum TypeConnectorQuery
        {
            sql,
            notFind
   
        }

        public int IdConnector { get; set; }

        public int IdQuery { get; set; }

        public string NameConnector { get; set; }

        public string ValueConnector { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public TypeConnectorQuery TypeConnector { get; set; }

        public static TypeConnectorQuery FindConnector(string v)
        {
            if (v == null)
            {
                return TypeConnectorQuery.notFind;
            }
            if (v.Equals(TypeConnectorQuery.sql.ToString())) { return TypeConnectorQuery.sql; }
           

            return TypeConnectorQuery.notFind;
        }
    }
}