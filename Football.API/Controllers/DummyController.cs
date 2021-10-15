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
            var MoldovaChisinau = new Location { Country = "Moldova", City = "Chisinau" };

            var MoldovaCantemir = new Location { Country = "Moldova", City = "Cantemir" };

            var RomaniaBucharest = new Location { Country = "Romania", City = "Bucharest" };

            var TransnistriaTiraspol = new Location { Country = "Transnistria", City = "Tiraspol" };

            var player1 = new Player { FirstName = "Nicolae", LastName = "Random" };

            var player2 = new Player { FirstName = "Victor", LastName = "Smith" };

            var player3 = new Player { FirstName = "Victoras", LastName = "Fam" };

            var player4 = new Player { FirstName = "Nichita", LastName = "Domi" };

            var player5 = new Player { FirstName = "Victor", LastName = "Torreto" };

            var player6 = new Player { FirstName = "Igor", LastName = "Random" };

            var player7 = new Player { FirstName = "Dumitru", LastName = "Rom" };

            var player8 = new Player { FirstName = "Octav", LastName = "Gutu" };

            var player9 = new Player { FirstName = "Nichita", LastName = "Domi" };

            var player10 = new Player { FirstName = "Victor", LastName = "Torreto" };

            var team1 = new Team { Players = { player1, player2, player3, player4, player5 }, Location = MoldovaCantemir, Name = "BestTeam"};

            var team2 = new Team { Players = { player9, player6, player7, player8, player10 }, Location = TransnistriaTiraspol, Name = "Sheriff" };

            var team3 = new Team { Players = { player5, player9, player4, player8, player7 }, Location = RomaniaBucharest, Name = "Bulldog" };

            var team4 = new Team { Players = { player3, player7, player4, player9, player2 }, Location = RomaniaBucharest, Name = "Fortuna" };



            var match1 = new Match {
                Location = TransnistriaTiraspol,
                DateTime = DateTime.Parse("2020.7.3 12:00"),
                FirstTeam = team1,
                SecondTeam = team2,
                FirstTeamGoals = 2,
                SecondTeamGoals = 1
            };
            var match2 = new Match
            {
                Location = RomaniaBucharest,
                DateTime = DateTime.Parse("2020.8.4 12:00"),
                FirstTeam = team1,
                SecondTeam = team3,
                FirstTeamGoals = 5,
                SecondTeamGoals = 0
            };
            var match3 = new Match
            {
                Location = RomaniaBucharest,
                DateTime = DateTime.Parse("2020.9.9 12:00"),
                FirstTeam = team2,
                SecondTeam = team4,
                FirstTeamGoals = 1,
                SecondTeamGoals = 1
            };
            _context.Add(match1);
            _context.Add(match2);
            _context.Add(match3);
            _context.SaveChanges();
            return Ok();
        }
    }
}

