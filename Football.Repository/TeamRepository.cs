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
    public class TeamRepository : ITeamRepository
    {
        private readonly FootballInfoContext _context;
        internal DbSet<Team> _dbSet;
        private readonly IMapper _mapper;

        public TeamRepository(FootballInfoContext context, IMapper mapper)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<Team>();
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<TeamDto>> GetAllTeamsAsync()
        {
            var result = _mapper.Map<IEnumerable<TeamDto>>(await _dbSet.Include(f => f.Players).Include(f => f.Location).ToListAsync());
            return result;
        }

        public async Task<IEnumerable<TeamWithoutPlayers>> GetAllTeamsWithoutPlayersAsync()
        {
            var result = _mapper.Map<IEnumerable<TeamWithoutPlayers>>(await _dbSet.Include(f => f.Players).Include(f => f.Location).ToListAsync());
            return result;
        }

        public void Insert(TeamForCreating match)
        {
            var team = new Team()
            {
                Location = _context.Locations.FirstOrDefault(f => f.City == match.Location) ??
                new Location { City = match.Location, Country = "Unkown" },
                Name = match.Name,
                Players = null
            };
            _dbSet.Add(team);
        }

        public bool TeamExists(int id)
        {
            var team = _dbSet.Find(id);
            return team != null;
        }

        public async Task<TeamDto> GetTeamByIdAsync(int id)
        {
            var team = _mapper.Map<TeamDto>(await _dbSet
                .Where(c => c.Id == id)
                .Include(f => f.Players)
                .Include(f => f.Location)
                .SingleAsync());

            return team;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
