using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionDB.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrescriptionID { get; set; }

        public DateTime Date { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(Patient))]
        public string PatientSSN { get; set; } = null!;
        public Patient? Patient { get; set; }

        [ForeignKey(nameof(Doctor))]
        public string DoctorSSN { get; set; } = null!;
        public Doctor? Doctor { get; set; }

        [ForeignKey(nameof(Drug))]
        public string DrugTradeName { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public Drug? Drug { get; set; }
    }
}