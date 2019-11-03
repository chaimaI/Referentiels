using BusinessContracts.Business.Contracts;
using BusinessDomain.Business.Domain.Contracts;
using BusinessDomain.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfrastructureBusiness.Infrasctructure.Business
{
    public class ClasseListeService : IClasseListeService
    {
        private readonly IClasseListeDataService _categoryDataService;

        public ClasseListeService(IClasseListeDataService categoryDataService)
        {
            _categoryDataService = categoryDataService;
        }


        public IEnumerable<ClasseListe> GetAllCatListes()
        {
            return _categoryDataService.GetAllCatListes();
        }


        public ClasseListe GetClasseListeById(int idCatListe)
        {
            return _categoryDataService.GetClasseListeById(idCatListe);
        }

  

    }
}