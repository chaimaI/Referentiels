using BusinessContracts.Business.Contracts;
using BusinessDomain.Business.Domain.Contracts;
using BusinessDomain.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfrastructureBusiness.Infrasctructure.Business
{
    public class LoginService : ILoginService
    {
        private readonly ILoginDataService _categoryDataService;

        public LoginService(ILoginDataService categoryDataService)
        {
            _categoryDataService = categoryDataService;
        }

        public IEnumerable<Login> Identification(string username, string password)
        {
            return _categoryDataService.Identification(username, password);
        } 
    }
}