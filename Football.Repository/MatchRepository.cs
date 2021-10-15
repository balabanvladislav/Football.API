using FotbalAPI.Contexts;
using FotbalAPI.Entities;
using FotbalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football.Repository
{
    public class MatchRepository : IMatchRepository
    {
        internal FootballInfoContext _context;
        internal DbSet<Match> _dbSet;

        public MatchRepository(FootballInfoContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
            _dbSet = context.Set<Match>();
        }
        public void Delete(Match matchToDelete)
        {
            _dbSet.Remove(matchToDelete);
        }

        public void Delete(int id)
        {
            var match = _context.Matches.Find(id);
            Delete(match);
        }

        // TODO: Mapping
        public IEnumerable<MatchDto> GetAll()
        {
            List<MatchDto> matches = new List<MatchDto>();

            foreach(var match in _dbSet.ToList())
            {
                var newMatch = new MatchDto
                {
                    FirstTeam = match.FirstTeam.Name,
                    SecondTeam = match.SecondTeam.Name,
                    Location = match.Location.City,
                    FirstTeamGoals = match.FirstTeamGoals,
                    SecondTeamGoals = match.SecondTeamGoals,
                    DateTime = match.DateTime.ToString()
                };
                matches.Add(newMatch);
            }

                return matches;
        }

        public Match GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Match GetMatchById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Match match)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Match matchToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
