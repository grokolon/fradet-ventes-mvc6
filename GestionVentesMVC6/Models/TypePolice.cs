using System.ComponentModel.DataAnnotations;

namespace GestionVentesMVC6.Models
{
    public class TypePolice
    {
        [Required]
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Type de police")]
        public string Nom { get; set; }
    }
}
