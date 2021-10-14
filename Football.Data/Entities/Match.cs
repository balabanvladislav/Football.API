using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotbalAPI.Entities
{
    public class Match
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [ForeignKey("FirstTeamId")]
        public Team FirstTeam { get; set; }

        [ForeignKey("SecondTeamId")]
        public Team SecondTeam { get; set; }

        public int FirstTeamGoals { get; set; }

        public int SecondTeamGoals { get; set; }
    }
}
