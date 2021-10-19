using Football.Data.Contexts;
using Football.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Football.API.Controllers
{
    /// <summary>
    /// Dummy controller to fast fill database
    /// </summary>
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

            var player4 = new Player { FirstName = "Nichita", LastName = "Sulac" };

            var player5 = new Player { FirstName = "Victor", LastName = "Torreto" };

            var player6 = new Player { FirstName = "Igor", LastName = "Random" };

            var player7 = new Player { FirstName = "Dumitru", LastName = "Rom" };

            var player8 = new Player { FirstName = "Octav", LastName = "Gutu" };

            var player9 = new Player { FirstName = "Nichita", LastName = "Domi" };

            var player10 = new Player { FirstName = "Victor", LastName = "Botez" };

            var player11 = new Player { FirstName = "Mihai", LastName = "Scurtu" };
                      
            var player12 = new Player { FirstName = "Andrei", LastName = "Lungu" };
                      
            var player13 = new Player { FirstName = "Ovidiu", LastName = "Domanciuc" };
                      
            var player14 = new Player { FirstName = "Ovidiu", LastName = "Medrigan" };
                      
            var player15 = new Player { FirstName = "Vitalic", LastName = "Butnar" };
                      
            var player16 = new Player { FirstName = "Vasea", LastName = "Fotbalistu" };
                      
            var player17 = new Player { FirstName = "Catalin", LastName = "Cheptea" };
                      
            var player18 = new Player { FirstName = "Viorel", LastName = "Lupascu" };
                      
            var player19 = new Player { FirstName = "Nume", LastName = "Prenume" };

            var player20 = new Player { FirstName = "Roberto", LastName = "Ronaldo" };

            var team1 = new Team { Players = { player1, player2, player3, player4, player5 }, Location = MoldovaCantemir, Name = "BestTeam"};

            var team2 = new Team { Players = { player6, player7, player8, player9, player10 }, Location = TransnistriaTiraspol, Name = "Sheriff" };

            var team3 = new Team { Players = { player11, player12, player13, player14, player15 }, Location = RomaniaBucharest, Name = "Bulldog" };

            var team4 = new Team { Players = { player16, player17, player18, player19, player20 }, Location = RomaniaBucharest, Name = "Fortuna" };



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
            var match4 = new Match
            {
                Location = MoldovaChisinau,
                DateTime = DateTime.Parse("2020.7.20 18:00"),
                FirstTeam = team3,
                SecondTeam = team2,
                FirstTeamGoals = 0,
                SecondTeamGoals = 0
            };
            _context.Add(match1);
            _context.Add(match2);
            _context.Add(match3);
            _context.Add(match4);
            _context.SaveChanges();
            return Ok();
        }
    }
}

