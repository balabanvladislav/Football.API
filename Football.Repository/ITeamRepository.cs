using Football.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.Repository
{
    public interface ITeamRepository
    {
        Task<IEnumerable<TeamDto>> GetAllTeamsAsync();
        Task<TeamDto> GetTeamByIdAsync(int id);
        Task<IEnumerable<TeamWithoutPlayers>> GetAllTeamsWithoutPlayersAsync();
        void Insert(TeamForCreating match);
        public bool TeamExists(int id);

        void Save();
    }
}
