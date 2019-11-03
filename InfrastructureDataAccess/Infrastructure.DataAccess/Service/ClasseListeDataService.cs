using BusinessDomain.Business.Domain.Contracts;
using BusinessDomain.Business.Domain.Models;
using InfrastructureDataAccess.Infrastructure.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InfrastructureDataAccess.Infrastructure.DataAccess
{
    public class ClasseListeDataService: IClasseListeDataService
    {
        private readonly ClasseListeRepository _repository = new ClasseListeRepository();

        public ClasseListeDataService()
        {
            _repository.SetConnectionString(ConfigurationManager.ConnectionStrings["BDD_Interface"].ConnectionString);
        }

        public IEnumerable<ClasseListe> GetAllCatListes()
        {
            return _repository.GetAllCatListes();
        }

        public ClasseListe GetClasseListeById(int idCatListe)
        {
            return _repository.GetClasseListeById(idCatListe);
        }

    }
}