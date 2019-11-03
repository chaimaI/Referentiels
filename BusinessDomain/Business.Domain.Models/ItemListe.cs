using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessDomain.Business.Domain.Models
{
    public class ItemListe
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Horaires { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Presences { get; set; }
        public string Commentaires { get; set; }
        public int IdClasses { get; set; }

    }
}