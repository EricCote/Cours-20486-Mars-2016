using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PremierMvc.Models
{
    public class Personne
    {
        public int PersonneID { get; set; }
        [StringLength(50)]
        public string Nom { get; set; }
        [StringLength(100)]
        public string Courriel { get; set; }
        [Display(Name ="Date de Naissance", ShortName = "Naissance")]
        public DateTime DateNaissance { get; set; }

    }
}