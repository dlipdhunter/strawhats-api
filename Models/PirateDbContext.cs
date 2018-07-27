namespace strawhats_api.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;

    public class PirateDbContext : DbContext
    {
        public PirateDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Pirate> Pirates { get; set; }
        public virtual DbSet<PirateCrew> PirateCrews { get; set; }

    }
}