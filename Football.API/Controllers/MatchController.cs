using Football.Repository;
using FotbalAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Controllers
{
    [ApiController]
    [Route("api/match")]
    public class MatchController : Controller
    {
        private IRepository<Match> _repository;

        public MatchController(MatchRepository<Match> repository)
        {
            _repository = repository ?? throw new NullReferenceException(nameof(repository));
        }
        [HttpGet]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
