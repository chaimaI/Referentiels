using BusinessDomain.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomain.Business.Domain.Contracts
{
    public interface IClasseListeDataService
    {
        IEnumerable<ClasseListe> GetAllCatListes();
        ClasseListe GetClasseListeById(int idClasseListe);
    
    }
}
