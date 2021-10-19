using AutoMapper;
using Football.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Football.API.Controllers
{
    [ApiController]
    [Route("api/matches")] 
    public class MatchController : Controller
    {
        private readonly IMatchRepository _repository;
        private readonly IMapper _mapper;

        public MatchController(IMatchRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new NullReferenceException(nameof(repository));
            _mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
        }
        [HttpGet]
        public IActionResult AllMatches()
        {
            var matches = _repository.GetMatches();

            return Ok(matches);
        }

        [HttpGet("byinterval")]
        public IActionResult ByInterval(DateTime from, DateTime to)
        {
            var matches = _repository.GetMatches()
                .Where(c => c.DateTime >= from && c.DateTime <= to);
            return Ok(matches);
        }

        [HttpGet("bylocation")]
        public IActionResult ByLocation(string city)
        {
            var matches = _repository.GetMatches()
                .Where(c => c.Location == city);
            return Ok(matches);
        }

        [HttpGet("byteam")]
        public IActionResult ByTeam(string team)
        {
            var matches = _repository.GetMatches()
                .Where(c => c.FirstTeam == team || c.SecondTeam == team);
            return Ok(matches);
        }


        [HttpGet("byplayer")]

        public IActionResult ByPlayer(string FirstName, string LastName)
        {
            var matches = _repository.GetByPlayer(FirstName, LastName);
            return Ok(matches);
        }

        [HttpGet("{id}")]
        public IActionResult GetMatch(int id)
        {

            var match = _repository.GetMatchById(id);
            return Ok(_repository.GetMatchById(id));
        }
    }
}
