using Football.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.Repository
{
    public interface IMatchRepository
    {
        Task<IEnumerable<MatchDto>> GetMatchesAsync();
        Task<IEnumerable<MatchDto>> GetByPlayerAsync(string FName, string LName);
        Task<MatchDto> GetMatchByIdAsync(int id);
        public bool PlayerExists(string FName, string LName);

    }
}
