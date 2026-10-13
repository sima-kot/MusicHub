using Microsoft.EntityFrameworkCore;
using MusicHub.Api.Models;

namespace MusicHub.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Track> Tracks => Set<Track>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>(e =>
            {
                e.Property(t => t.Title).IsRequired().HasMaxLength(200);
                e.Property(t => t.Artist).HasMaxLength(200);
                e.Property(t => t.Status).HasConversion<string>();
            });
        }
    }
    
    
}
