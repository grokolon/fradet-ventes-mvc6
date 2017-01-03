using System.ComponentModel.DataAnnotations;

namespace GestionVentesMVC6.Models
{
    public class Compagnie
    {
        [Required]
        [Key]
        public int ID { get; set; }
        [Display(Name ="Compagnie")]
        public string Nom { get; set; }
    }
}
