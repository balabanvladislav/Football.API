using Football.Data;
using System.Collections.Generic;

namespace Football.Data.Models
{
    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public LocationDto Location { get; set; }

        public ICollection<PlayerDto> Players { get; set; }
          = new List<PlayerDto>();
    }
}
