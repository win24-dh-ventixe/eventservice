using Microsoft.EntityFrameworkCore;
using Presentation.Models;

namespace Presentation.Data;

public class EventDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<EventEntity> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventEntity>()
            .Property(e => e.Price)
            .HasPrecision(10, 2);
    }
}