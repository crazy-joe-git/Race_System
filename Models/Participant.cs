using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_System.Models
{
    [Table("Participant")]
    public class Participant
    {
        [Key]
        public int ParticipantID { get; set; } // Primary Key

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        // Extra fields needed for Part 2 authentication & role enforcement
        public string? PasswordHash { get; set; }
        public string? Role { get; set; } // "Organiser" or "Participant"
    }
}
