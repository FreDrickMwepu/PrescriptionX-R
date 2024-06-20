using System.ComponentModel.DataAnnotations;
using PrescriptionDB.Model;

namespace PrescriptionDB.Models
{
    public class PharmaceuticalCompany
    {
        [Key]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(15)]
        public string PhoneNumber { get; set; } = null!;

        public ICollection<Drug> Drugs { get; set; } = new HashSet<Drug>();
        public ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    }
}