using Football.Data.Models;
using Football.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamController : Controller
    {
        private readonly ITeamRepository _repository;

        public TeamController(ITeamRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IActionResult GetAllTeams()
        {
            var result = _repository.GetAllTeams();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_repository.TeamExists(id))
            {
                return NotFound();
            }

            var result = _repository.GetTeamById(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Insert(TeamForCreating newMatch)
        {
            _repository.Insert(newMatch);
            _repository.Save();
            return Ok();
        }
    }
}
