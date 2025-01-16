using Microsoft.EntityFrameworkCore;

namespace Projekt1._1;
using Projekt1._1.BasicObjects;

// Class for saving the information in Database
public class VolleyballContext : DbContext
{
    // General properties
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<MatchInfo> Matches { get; set; }

    // OnConfiguring method for getting the link of Database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VolleyballDB;" +
                                 "Username=postgres;Password=postgres;");
    }

    // Ruler method for taking in attention all the exceptions and other stuff, so the data will be considered between 
    // program and database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.Ignore(t => t.Winners);
            entity.HasKey(w => w.Id);
            
            entity.HasMany(t => t.Matches)
                .WithOne(m => m.Tournament)
                .HasForeignKey(m => m.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Ignore(t => t.TeamDictionary);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.Ignore(p => p.PlayerInformationStatistics);
            entity.Ignore(p => p.PlayerInformationPoints);
            entity.HasKey(p => p.Id);
            
            entity.HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<MatchInfo>(entity =>
        {
            entity.HasOne(m => m.Tournament)
                .WithMany(t => t.Matches)
                .HasForeignKey(m => m.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasKey(m => m.Id);
            
            entity.HasOne(m => m.Team1)
                .WithMany()
                .HasForeignKey("Team1Id")
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasOne(m => m.Team2)
                .WithMany()
                .HasForeignKey("Team2Id")
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasOne(m => m.Winner)
                .WithMany()
                .HasForeignKey("WinnerId")
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasOne(m => m.Loser)
                .WithMany()
                .HasForeignKey("LoserId")
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
