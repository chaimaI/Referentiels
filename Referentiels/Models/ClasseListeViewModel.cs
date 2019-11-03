using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Referentiels.Models
{
    public class ClasseListeViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Libellé")]
        [MaxLength(50, ErrorMessage = "Le libellé ne doit pas dépasser 50 caractères")]
        public string NomClasses { get; set; }

        [Display(Name = "Niveau de la classe")]
        public int Niveau { get; set; }


        [Display(Name = "Url de l'image")]
        public string Images { get; set; }
    }
}