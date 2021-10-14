using System.Collections.Generic;

namespace FotbalAPI.Models
{
    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public LocationDto Location { get; set; }

        public ICollection<PlayerDto> Players { get; set; }
          = new List<PlayerDto>();
        //public Player FirstPlayer { get; set; }
        //public Player SecondPlayer { get; set; }
        //public Player ThirdPlayer { get; set; }
        //public Player FourthPlayer { get; set; }
        //public Player FifthPlayer { get; set; }
    }
}
