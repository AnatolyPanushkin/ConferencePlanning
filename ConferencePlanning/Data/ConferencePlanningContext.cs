using ConferencePlanning.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanning.Data;

public class ConferencePlanningContext:DbContext
{
    public ConferencePlanningContext(DbContextOptions<ConferencePlanningContext> options):base(options)
    {
        
    }
    
    public DbSet<Conference> Conferences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Server=localhost;Port=5432;Database=ConferencePlanning;Username=postgres;Password=1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("adminpack")
            .HasAnnotation("Relational:Collation", "Russian_Russia.1251");

        modelBuilder.Entity<Conference>(entity => { entity.HasKey(conference => new {conference.Id}); });
    }
}

