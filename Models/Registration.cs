using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_System.Models
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        public int RegistrationID { get; set; } // Primary Key

        [Required]
        public DateTime Reg_Date { get; set; }

        [Required]
        public int BidNumber { get; set; }

        [Required]
        public string PaymentStatus { get; set; } = string.Empty; // e.g., "Paid", "Pending"

        public int ParticipantID { get; set; } // Foreign Key to Participant
        public int EventRaceID { get; set; } // Foreign Key to EventRace
    }
}