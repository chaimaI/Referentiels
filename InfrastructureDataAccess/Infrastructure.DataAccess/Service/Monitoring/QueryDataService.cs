using BusinessDomain.Business.Domain.Contracts.Monitoring;
using BusinessDomain.Business.Domain.Models.Monitoring;
using InfrastructureDataAccess.Infrastructure.DataAccess.Repository.Monitoring;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InfrastructureDataAccess.Infrastructure.DataAccess.Service.Monitoring
{
    public class QueryDataService: IQueryDataService
    {
        private readonly QueryRepository _repository = new QueryRepository();

        public QueryDataService()
        {
            _repository.SetConnectionString(ConfigurationManager.ConnectionStrings["BDD_Interface"].ConnectionString);
        }

        public List<Query> GetQueryAvailable()
        {
            return _repository.GetQueryAvailable();

        }

        public void ExecuteQuery(Query q)
        {
            _repository.ExecuteQuery(q);
        }
    }
}