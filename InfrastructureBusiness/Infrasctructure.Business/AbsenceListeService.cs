using BusinessContracts.Business.Contracts;
using BusinessDomain.Business.Domain.Contracts;
using BusinessDomain.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfrastructureBusiness.Infrasctructure.Business
{
    public class AbsenceListeService : IAbsenceListeService
    {
        private readonly IAbsenceListeDataService _categoryDataService;

        public AbsenceListeService(IAbsenceListeDataService categoryDataService)
        {
            _categoryDataService = categoryDataService;
        }


        public IEnumerable<ItemListe> GetAllItemListByList(int idList)
        {
            return _categoryDataService.GetAllItemListByList(idList);
        }

        public ItemListe GetItemListById(int idItemList)
        {
            return _categoryDataService.GetItemListById(idItemList);
        }

        public int CreateAbsenceListe(DateTime date, string horaires, string nom, string prenom, string presences, string commentaires, int idClasses)
        {
            return _categoryDataService.CreateAbsenceListe(date, horaires, nom, prenom, presences, commentaires, idClasses);
        }


        public void UpdateAbsenceListe(int Id, DateTime date, string horaires, string nom, string prenom, string presences, string commentaires, int idClasses)
        {
           _categoryDataService.UpdateAbsenceListe(Id,date, horaires, nom, prenom, presences, commentaires, idClasses);
        }

    }
}