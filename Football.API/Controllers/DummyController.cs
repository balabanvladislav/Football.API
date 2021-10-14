using FotbalAPI.Contexts;
using FotbalAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Football.API.Controllers
{
    [ApiController]
    [Route("api/filldatabase")]
    public class DummyController : ControllerBase
    {
        private readonly FootballInfoContext _context;

        public DummyController(FootballInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public IActionResult Fill()
        {
            var model = new Match {
                Location = new Location { Country="Italy", Name="Rime" }, 
                DateTime = DateTime.Now, 
                FirstTeam = new Team {Name = "Idiotii", Location = null, Players = null },
                SecondTeam = new Team { Name = "Idiotii 3", Location = null, Players = null },
                FirstTeamGoals = 2,
                SecondTeamGoals = 1
            };
            _context.Add(model);
            _context.SaveChanges();
            return Ok();
        }
    }
}

