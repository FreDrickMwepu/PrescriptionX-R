using System.ComponentModel.DataAnnotations;
using PrescriptionDB.Model;

namespace PrescriptionDB.Models
{
    public class Doctor
    {
        [Key]
        [StringLength(9)]
        public string SSN { get; set; } = null!;

        [StringLength(100)]
        public string Name { get; set; } = null!;
        public string Specialty { get; set; } = null!;
        public int YearsOfExperience { get; set; }

        public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
        public ICollection<Contract> SupervisedContracts { get; set; } = new HashSet<Contract>();
    }
}