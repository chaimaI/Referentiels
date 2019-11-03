using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfrastructureDataAccess
{
    public abstract class AbstractRepository
    {
        protected string ConnectionString { get; set; }

        public void SetConnectionString(string connectionString) => this.ConnectionString = connectionString;


    }
}