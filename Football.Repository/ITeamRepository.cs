using Football.Data.Models;
using System.Collections.Generic;

namespace Football.Repository
{
    public interface ITeamRepository
    {
        IEnumerable<TeamDto> GetAllTeams();
        TeamDto GetTeamById(int id);
        void Insert(TeamForCreating match);
        public bool TeamExists(int id);

        void Save();
    }
}
