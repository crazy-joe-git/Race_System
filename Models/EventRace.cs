using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_System.Models
{
    [Table("EventRace")]
    public class EventRace
    {
        [Key]
        public int EventRaceID { get; set; } 

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public int MaxParticipants { get; set; }

        public int EventID { get; set; }
        public int CategoryID { get; set; } 
    }
}