using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Referentiels.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Horaires { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Presences { get; set; }
        public string Commentaires { get; set; }
        public int IdClasses { get; set; }

        public List<ListItem> AbsencesByClasses { get; set; }

        /// <summary>
        /// Get or Set le message success lors d'une action sur un élément de liste
        /// </summary>
        public string MessageSuccess { get; set; }

        /// <summary>
        /// Get or Set le message error lors d'une action sur un élément de liste
        /// </summary>
        public string MessageError { get; set; }

    }
}