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
        private IRepository<Match> _repository;

        public MatchController(IRepository<Match> repository)
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
            [FromBody]Match matchDto)
        {
            _repository.Insert(matchDto);
        }
    }
}
