using AutoMapper;
using Football.Data.Contexts;
using Football.Data.Entities;
using Football.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamDto> GetAllTeams()
        {
            return (_mapper.Map<IEnumerable<TeamDto>>(_dbSet.Include(f => f.Players).Include(f => f.Location)));
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
            return team  != null;
        }

        public TeamDto GetTeamById(int id)
        {
            var team = _mapper.Map<TeamDto>(_dbSet
                .Where(c => c.Id == id)
                .Include(f => f.Players)
                .Include(f => f.Location)
                .FirstOrDefault());

            return team;
        }

       

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
