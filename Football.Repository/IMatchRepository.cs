using Football.Data.Entities;
using Football.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Repository
{
    public interface IMatchRepository
    {
        IEnumerable<MatchDto> GetAll();
        IEnumerable<MatchDto> GetByPlayer(string FName, string LName);
        MatchDto GetMatchById(int id);
        void Insert(Match match);
        void Update(Match matchToUpdate);
        void Delete(Match matchToDelete);
        void Delete(int id);

        void Save();
    }
}
