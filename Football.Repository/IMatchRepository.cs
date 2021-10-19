using Football.Data.Entities;
using Football.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Repository
{
    public interface IMatchRepository
    {
        IEnumerable<MatchDto> GetMatches();
        IEnumerable<MatchDto> GetByPlayer(string FName, string LName);
        MatchDto GetMatchById(int id);
        public bool PlayerExists(string FName, string LName);

    }
}
