using BusinessDomain.Business.Domain.Models.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomain.Business.Domain.Contracts.Monitoring
{
    public interface IQueryDataService
    {
        void ExecuteQuery(Query q);
        List<Query> GetQueryAvailable();
    }
}
