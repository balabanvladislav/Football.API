﻿using FotbalAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FotbalAPI.Contexts
{
    public class FootballInfoContext : DbContext
    {
        public FootballInfoContext(DbContextOptions<FootballInfoContext> options) :
            base(options)
        {
            // Daca BD exista, nu se va intampla nimic, dar daca nu, aceasta se va cres
            //Database.EnsureCreated();
        }
        public DbSet<Match> Matches { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Location> Locations { get; set; }

        //public FottbalInfoContext(DbContextOptions<FottbalInfoContext> options):
        //    base(options)
        //{
        //    Database.EnsureCreated();
        //}
    }
}
