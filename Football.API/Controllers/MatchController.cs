using AutoMapper;
using Football.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiController]
    [Route("api/matches")]
    public class MatchController : Controller
    {
        private readonly IMatchRepository _repository;
        private readonly IMapper _mapper;

        public MatchController(IMatchRepository repository, IMapper mapper)
        {
            _repository = repository ??
                throw new NullReferenceException(nameof(repository));
            _mapper = mapper ??
                throw new NullReferenceException(nameof(mapper));
        }
        [HttpGet]
        public async Task<IActionResult> AllMatches()
        {
            var matches = await _repository.GetMatchesAsync();


            return Ok(matches);
        }

        [HttpGet("byinterval")]

        public async Task<IActionResult> ByInterval(string beginDate, string endDate)
        {
            DateTime from;
            DateTime to;
            try
            {
                from = DateTime.Parse(beginDate);
                to = DateTime.Parse(endDate);
            }
            catch
            {
                return StatusCode(500, "Wrong data format!");
            }

            var matches = (await _repository.GetMatchesAsync())
                .Where(c => c.DateTime >= from && c.DateTime <= to);

            if (matches == null)
                return NotFound();

            return Ok(matches);
        }

        [HttpGet("bylocation")]
        public async Task<IActionResult> ByLocation(string city)
        {
            var matches = (await _repository.GetMatchesAsync())
                .Where(c => c.Location == city);

            if (matches.Count() == 0)
                return NotFound();

            return Ok(matches);
        }

        [HttpGet("byteam")]
        public async Task<IActionResult> ByTeam(string team)
        {
            var matches = (await _repository.GetMatchesAsync())
                .Where(c => c.FirstTeam.ToLower() == team.ToLower() || c.SecondTeam.ToLower() == team.ToLower());

            if (matches.Count() == 0)
                return NotFound();

            return Ok(matches);
        }


        [HttpGet("byplayer")]

        public async Task<IActionResult> ByPlayer(string FirstName, string LastName)
        {

            if (!_repository.PlayerExists(FirstName, LastName))
                return NotFound();

            var matches = await _repository.GetByPlayerAsync(FirstName, LastName);

            if (matches.Count() == 0)
                return NotFound();

            return Ok(matches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatch(int id)
        {

            var match = await _repository.GetMatchByIdAsync(id);

            if (match == null)
                return NotFound();

            return Ok(match);
        }
    }
}
