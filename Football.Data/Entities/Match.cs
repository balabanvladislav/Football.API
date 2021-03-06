using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.Data.Entities
{
    public class Match
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [Required]
        [ForeignKey("FirstTeamId")]
        public Team FirstTeam { get; set; }

        [Required]
        [ForeignKey("SecondTeamId")]
        public Team SecondTeam { get; set; }

        [Required]
        public int FirstTeamGoals { get; set; }

        [Required]
        public int SecondTeamGoals { get; set; }
    }
}
