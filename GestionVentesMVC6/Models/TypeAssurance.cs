using System.ComponentModel.DataAnnotations;

namespace GestionVentesMVC6.Models
{
    public class TypeAssurance
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Type d'assurance")]
        public string Nom { get; set; }

        [Display(Name = "Pourcentage de commission par défaut")]
        public double PourcentageCommissionParDefaut { get; set; }
    }
}
