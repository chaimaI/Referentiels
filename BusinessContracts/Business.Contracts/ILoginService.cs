using System;
using BusinessDomain.Business.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContracts.Business.Contracts
{
    public interface ILoginService
    {
        IEnumerable<Login> Identification( string username, string password);
    }
}
