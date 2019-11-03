using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessDomain.Business.Domain.Models
{
    public class ClasseListe
    {
        public int Id { get; set; }
        public string NomClasses { get; set; }
        public int Niveau { get; set; }
        public string Images { get; set; }

    }
}