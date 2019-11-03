using BusinessDomain.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContracts.Business.Contracts
{
    public interface IAbsenceListeService
    {
        IEnumerable<ItemListe> GetAllItemListByList(int idList);
        ItemListe GetItemListById(int idItemList);
        int CreateAbsenceListe(DateTime date, string horaires, string nom, string prenom, string presences,string commentaires, int idClasses);
        void UpdateAbsenceListe(int Id,DateTime date, string horaires, string nom, string prenom, string presences, string commentaires, int idClasses);
    }
}
