using Microsoft.EntityFrameworkCore;
using CasoPractico1.Models;
using System.Collections.Generic;

namespace CasoPractico1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
    }
}
