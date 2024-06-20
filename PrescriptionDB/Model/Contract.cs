using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionDB.Models
{
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractID { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Text { get; set; } = null!;

        [ForeignKey(nameof(PharmaceuticalCompany))]
        public string CompanyName { get; set; } = null!;
        public PharmaceuticalCompany? PharmaceuticalCompany { get; set; }

        [ForeignKey(nameof(Pharmacy))]
        public string PharmacyName { get; set; } = null!;
        public Pharmacy? Pharmacy { get; set; }

        [ForeignKey(nameof(Supervisor))]
        public string SupervisorSSN { get; set; } = null!;
        public Doctor? Supervisor { get; set; }
    }
}