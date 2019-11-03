using BusinessDomain.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessDomain.Business.Domain.Contracts
{
    public interface ILoginDataService
    {
        IEnumerable<Login> Identification(string username, string password);
    }
}