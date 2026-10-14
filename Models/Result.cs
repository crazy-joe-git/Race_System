using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_System.Models
{
    [Table("Result")]
    public class Result
    {
        [Key]
        public int ResultID { get; set; } 

        [Required]
        public TimeSpan FinishTime { get; set; }

        [Required]
        public int RankOverall { get; set; }

        [Required]
        public int RankInCategory { get; set; }

        public int RegistrationID { get; set; } 
    }
}