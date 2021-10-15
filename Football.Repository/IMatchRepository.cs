using FotbalAPI.Entities;
using FotbalAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Repository
{
    public interface IMatchRepository
    {
        IEnumerable<MatchDto> GetAll();
        Match GetMatchById(int id);
        void Insert(Match match);
        void Update(Match matchToUpdate);
        void Delete(Match matchToDelete);
        void Delete(int id);

        void Save();
    }
}
