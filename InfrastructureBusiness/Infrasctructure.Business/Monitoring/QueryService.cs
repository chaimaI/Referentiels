using BusinessContracts.Business.Contracts.Monitoring;
using BusinessDomain.Business.Domain.Contracts.Monitoring;
using BusinessDomain.Business.Domain.Models.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfrastructureBusiness.Infrasctructure.Business.Monitoring
{
    public class QueryService : IQueryService
    {
        private readonly IQueryDataService _categorieDataService;

        public QueryService(IQueryDataService categoryDataService)
        {
            _categorieDataService = categoryDataService;
        }

        public List<Query> GetQueryAvailable()
        {
            return _categorieDataService.GetQueryAvailable();
        }

        public void ExecuteQuery(Query q)
        {
            _categorieDataService.ExecuteQuery(q);
        }


    }
}