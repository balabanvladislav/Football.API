using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.Data.Entities
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public ICollection<Player> Players { get; set; }
          = new List<Player>();
    }
}
