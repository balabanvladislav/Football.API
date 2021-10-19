using Football.Data.Entities;
using Football.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Repository
{
    public interface ITeamRepository
    {
        IEnumerable<TeamDto> GetAllTeams();
        TeamDto GetTeamById(int id);
        void Insert(Team match);
        void Update(Team matchToUpdate);
        void Delete(int id);

        void Save();
    }
}
