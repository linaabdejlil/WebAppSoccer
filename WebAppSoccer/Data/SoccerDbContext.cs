using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppSoccer.Models;

namespace WebAppSoccer.Data
{
    public class SoccerDbContext : DbContext
    {
        public SoccerDbContext (DbContextOptions<SoccerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Joueur> Joueurs { get; set; } = default!;
        public DbSet<Club> Clubs { get; set; } = default!;
        public DbSet<Match> Matches { get; set; } = default!;
        public DbSet<Participer> Participers { get; set; } = default!;
    }
}
