using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PrescriptionDB.Model;

namespace PrescriptionDB.Models
{
    public class Patient
    {
        [Key]
        [StringLength(9)]
        public string SSN { get; set; } = null!;

        [StringLength(100)]
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Age { get; set; }

        [ForeignKey(nameof(PrimaryPhysician))]
        public string? PrimaryPhysicianSSN { get; set; }
        public Doctor? PrimaryPhysician { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
    }
}