namespace FotbalAPI.Models
{
    public class MatchDto
    {

        public int Id { get; set; }

        public LocationDto Location { get; set; }

        public TeamDto FirstTeam { get; set; }

        public TeamDto SecondTeam { get; set; }

        public int FirstTeamGoals { get; set; }

        public int SecondTeamGoals { get; set; }


    }
}
