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
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<Team>();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamDto> GetAllTeams()
        {
            //var result = _mapper.Map<IEnumerable<TeamDto>>(_dbSet
            //    .Include(f => f.Location)
            //    .Include(f => f.Players)
            //    ).ToList();
            var teamDto = new List<TeamDto>();
            foreach(var team in _dbSet.Include(f => f.Location).Include(f => f.Players))
            {
                var dtoT = new TeamDto
                {
                    Id = team.Id,
                    Location = team.Location.City,
                    Name = team.Name,
                    Players = new List<PlayerDto>()
                };
                
                foreach(var player in team.Players)
                {
                    dtoT.Players.Add(new PlayerDto
                    {
                        Id = player.Id,
                        FirstName = player.FirstName,
                        LastName = player.LastName
                    });
                }
                teamDto.Add(dtoT);
            }
            return teamDto;
        }

        public TeamDto GetTeamById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Team match)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Team matchToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
