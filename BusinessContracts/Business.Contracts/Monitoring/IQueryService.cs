using BusinessDomain.Business.Domain.Models.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContracts.Business.Contracts.Monitoring
{
    public interface IQueryService
    {
        void ExecuteQuery(Query q);
        List<Query> GetQueryAvailable();
    }
}
