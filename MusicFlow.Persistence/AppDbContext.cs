using Microsoft.EntityFrameworkCore;
using MusicFlow.Domain.Entites;
using MusicFlow.Persistence.SeedData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<DSP> DSPs { get; set; }
        public DbSet<TrackDistribution> TrackDistributions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            SeedData.Seed(modelBuilder);
        }
    }
}
