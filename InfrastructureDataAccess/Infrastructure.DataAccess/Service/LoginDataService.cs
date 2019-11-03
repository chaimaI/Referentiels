using BusinessDomain.Business.Domain.Contracts;
using BusinessDomain.Business.Domain.Models;
using InfrastructureDataAccess.Infrastructure.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InfrastructureDataAccess.Infrastructure.DataAccess.Service
{
    public class LoginDataService : ILoginDataService
    {
        private readonly LoginRepository _repository = new LoginRepository();

        public LoginDataService()
        {
            _repository.SetConnectionString(ConfigurationManager.ConnectionStrings["BDD_Interface"].ConnectionString);
        }


        public IEnumerable<Login> Identification(string username, string password)
        {
            return _repository.Identification(username, password);
        }
    }
}