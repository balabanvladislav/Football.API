using Football.Data.Models;
using Football.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Football.API.Controllers
{
    [ApiVersion("1.0")]
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
        public async Task<IActionResult> GetAllTeams()
        {
            var result = await _repository.GetAllTeamsAsync();
            return Ok(result);
        }

        [MapToApiVersion("1.1")]
        [HttpGet]
        public async Task<IActionResult> GetAllTeamsWithoutPlayers()
        {
            var result = await _repository.GetAllTeamsWithoutPlayersAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!_repository.TeamExists(id))
            {
                return NotFound();
            }

            var result = await _repository.GetTeamByIdAsync(id);
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
