using System.ComponentModel.DataAnnotations;

namespace GestionVentesMVC6.Models
{
    public class Vendeur
    {
        [Required]
        [Key]
        public int ID { get; set; }
        [Display(Name = "Vendeur")]
        public string Nom { get; set; }
        public bool Actif { get; set; }

    }
}
