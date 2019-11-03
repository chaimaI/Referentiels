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
    public class AbsenceListeDataService: IAbsenceListeDataService
    {

        private readonly AbsenceListeRepository _repository = new AbsenceListeRepository();

        public AbsenceListeDataService()
        {
            _repository.SetConnectionString(ConfigurationManager.ConnectionStrings["BDD_Interface"].ConnectionString);
        }



        public IEnumerable<ItemListe> GetAllItemListByList(int idList)
        {
            return _repository.GetAllItemListByList(idList);
        }

        public ItemListe GetItemListById(int idItemList)
        {
            return _repository.GetItemListById(idItemList);
        }

        public int CreateAbsenceListe(DateTime date, string horaires, string nom, string prenom, string presences, string commentaires, int idClasses)
        {
            return _repository.CreateAbsenceListe(date, horaires, nom, prenom, presences, commentaires, idClasses);
        }

        public void UpdateAbsenceListe(int Id,DateTime date, string horaires, string nom, string prenom, string presences, string commentaires, int idClasses)
        {
           _repository.UpdateAbsenceListe(Id, date, horaires, nom, prenom, presences, commentaires, idClasses);
        }

    }

}