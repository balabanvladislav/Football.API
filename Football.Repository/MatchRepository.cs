using AutoMapper;
using Football.Data.Contexts;
using Football.Data.Entities;
using Football.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Repository
{
    public class MatchRepository : IMatchRepository
    {
        internal FootballInfoContext _context;
        internal DbSet<Match> _dbSet;
        private readonly IMapper _mapper;

        public MatchRepository(FootballInfoContext context, IMapper mapper)
        {
            _context = context
                ?? throw new NullReferenceException(nameof(context));
            _dbSet = context.Set<Match>();

            _mapper = mapper
                ?? throw new NullReferenceException(nameof(mapper));
        }
        // TODO: Mapping
        public async Task<IEnumerable<MatchDto>> GetMatchesAsync()
        {

            var result = _mapper.Map<IEnumerable<MatchDto>>(await _dbSet
                .Where(c => c.Id > 0)
                .Include(f => f.Location)
                .Include(f => f.FirstTeam)
                .Include(f => f.SecondTeam)
                .ToListAsync());

            return result;
        }

        public async Task<IEnumerable<MatchDto>> GetByPlayerAsync(string FName, string LName)
        {

            var player = await _context.Players
                .Include(f => f.Team).FirstOrDefaultAsync(c => c.FirstName == FName && c.LastName == LName);

            var result = _mapper.Map<IEnumerable<MatchDto>>(await _dbSet
                .Where(c => c.FirstTeam.Id == player.Team.Id || c.SecondTeam.Id == player.Team.Id)
                .Include(f => f.Location)
                .Include(f => f.FirstTeam)
                .Include(f => f.SecondTeam)
                .ToListAsync());

            return result;
        }

        public bool PlayerExists(string FName, string LName)
        {
            var player = _context.Players
                .Any(c => c.FirstName == FName && c.LastName == LName);
            return player;
        }

        public async Task<MatchDto> GetMatchByIdAsync(int id)
        {
            var match = await _dbSet.Where(c => c.Id == id).Include(f => f.Location)
                .Include(f => f.FirstTeam)
                .Include(f => f.SecondTeam)
                .FirstOrDefaultAsync();


            return _mapper.Map<MatchDto>(match);
        }
    }
}
