using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionDB.Models
{
    public class PharmacyDrug
    {
        [ForeignKey(nameof(Pharmacy))]
        public string PharmacyName { get; set; } = null!;
        public Pharmacy? Pharmacy { get; set; }

        [ForeignKey(nameof(Drug))]
        public string DrugTradeName { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public Drug? Drug { get; set; }

        public decimal Price { get; set; }
    }
}