using BusinessDomain.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Referentiels.Models
{
    public class LoginModel
    {
        [Required (ErrorMessage="champ obligatoire")]
        public string username { get; set; }
        [Required(ErrorMessage = "champ obligatoire")]
        public string password { get; set; }

        public IEnumerable<Login> login { get; set; }
    }
}