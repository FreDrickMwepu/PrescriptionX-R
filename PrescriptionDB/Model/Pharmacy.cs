using System.ComponentModel.DataAnnotations;

namespace PrescriptionDB.Models
{
    public class Pharmacy
    {
        [Key]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;
        [StringLength(15)]
        public string PhoneNumber { get; set; } = null!;

        public ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
        public ICollection<PharmacyDrug> PharmacyDrugs { get; set; } = new HashSet<PharmacyDrug>();
    }
}