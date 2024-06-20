using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionDB.Models
{
    public class Drug
    {
        [StringLength(100)]
        public string TradeName { get; set; } = null!;

        public string Formula { get; set; } = null!;

        [ForeignKey(nameof(PharmaceuticalCompany))]
        public string CompanyName { get; set; } = null!;
        public PharmaceuticalCompany? PharmaceuticalCompany { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
        public ICollection<PharmacyDrug> PharmacyDrugs { get; set; } = new HashSet<PharmacyDrug>();
    }
}