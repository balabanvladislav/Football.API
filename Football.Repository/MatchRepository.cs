using AutoMapper;
using Football.Data.Contexts;
using Football.Data.Entities;
using Football.Data.Models;
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
        private readonly IMapper _mapper;

        public MatchRepository(FootballInfoContext context, IMapper mapper)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
            _dbSet = context.Set<Match>();
            _mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
        }  
        // TODO: Mapping
        public IEnumerable<MatchDto> GetMatches()
        {

            var result = _mapper.Map<IEnumerable<MatchDto>>(_dbSet
                .Where(c => c.Id > 0)
                .Include(f => f.Location)
                .Include(f => f.FirstTeam)
                .Include(f => f.SecondTeam))
                .ToList();

            return result;
        }

        public IEnumerable<MatchDto> GetByPlayer(string FName, string LName)
        {

            var player = _context.Players
                .Include(f => f.Team)
                .FirstOrDefault(c => c.FirstName == FName && c.LastName == LName);

            var result = _mapper.Map<IEnumerable<MatchDto>>(_dbSet
                .Where(c => c.FirstTeam.Id == player.Team.Id || c.SecondTeam.Id == player.Team.Id)
                .Include(f => f.Location)
                .Include(f => f.FirstTeam)
                .Include(f => f.SecondTeam))
                .ToList();

            return result;
        }

        public MatchDto GetMatchById(int id)
        {
            var match = _dbSet.Where(c => c.Id == id).Include(f => f.Location)
                .Include(f => f.FirstTeam)
                .Include(f => f.SecondTeam)
                .ToList().FirstOrDefault();


            return _mapper.Map<MatchDto>(match);
        }
    }
}
