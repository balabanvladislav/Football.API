namespace FotbalAPI.Models
{
    public class MatchDto
    {

        public int Id { get; set; }

        public string Location { get; set; }

        public string DateTime { get; set; }

        public string FirstTeam { get; set; }

        public string SecondTeam { get; set; }

        public int FirstTeamGoals { get; set; }

        public int SecondTeamGoals { get; set; }


    }
}
