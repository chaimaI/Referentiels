using BusinessDomain.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContracts.Business.Contracts
{
    public interface IClasseListeService
    {
        IEnumerable<ClasseListe> GetAllCatListes();
        ClasseListe GetClasseListeById(int idClasseListe);


    }
}
