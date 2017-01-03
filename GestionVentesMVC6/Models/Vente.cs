using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionVentesMVC6.Models
{
    public class Vente
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Display(Name = "Type de police")]
        public int TypePoliceID { get; set; }

        [Display(Name = "Type de police")]
        [ForeignKey("TypePoliceID")]
        public TypePolice TypePolice { get; set; }

        [Display(Name = "Type d'assurance")]
        public int TypeAssuranceID { get; set; }

        [Display(Name = "Type d'assurance")]
        [ForeignKey("TypeAssuranceID")]
        public TypeAssurance TypeAssurance { get; set; }

        [Display(Name = "Compagnie")]
        public int CompagnieID { get; set; }

        [Display(Name = "Compagnie")]
        [ForeignKey("CompagnieID")]
        public Compagnie Compagnie { get; set; }

        [Display(Name = "Vendeur")]
        public int VendeurID { get; set; }

        [Display(Name = "Vendeur")]
        [ForeignKey("VendeurID")]
        public Vendeur Vendeur { get; set; }

        [Required]
        public string Client { get; set; }

        [Required]
        [Display(Name = "Montant total de la prime")]
        [DataType(DataType.Currency)]
        public double MontantPrimeTotal { get; set; }

        [Display(Name = "Pourcentage de commission")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public double PourcentageCommission { get; set; }

        [Display(Name = "Date de vente")]
        public DateTime DateVente { get; set; }

        [Display(Name = "Référence")]
        public string Reference { get; set; }
    }
}
