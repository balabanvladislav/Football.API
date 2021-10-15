using Football.Repository;
using FotbalAPI.Entities;
using FotbalAPI.Models;
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
        private IMatchRepository _repository;

        public MatchController(IMatchRepository repository)
        {
            _repository = repository ?? throw new NullReferenceException(nameof(repository));
        }
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(_repository.GetAll());
        }
        [HttpPost]
        public void Create(
            [FromBody]MatchDto matchDto)
        {
            var match = new Match()
            {
                DateTime = DateTime.Parse(matchDto.DateTime),
            };
            _repository.Insert(match);
        }
    }
}
