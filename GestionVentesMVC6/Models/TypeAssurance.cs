using System;
using System.ComponentModel.DataAnnotations;

namespace GestionVentesMVC6.Models
{
    public class TypeAssurance
    {
        public int ID { get; set; }

        [Required]
        public string Nom { get; set; }

        [Display(Name ="Pourcentage de commission par défaut")]
        public double PourcentageCommissionParDefaut { get; set; }
    }
}
