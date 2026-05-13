
using Microsoft.EntityFrameworkCore;
using SoccerCoach.Api.Models;

namespace SoccerCoach.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Player> Players => Set<Player>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<PlayerPosition> PlayerPositions => Set<PlayerPosition>();
    public DbSet<Match> Matches => Set<Match>();
    public DbSet<MatchEvent> MatchEvents => Set<MatchEvent>();
    public DbSet<Substitution> Substitutions => Set<Substitution>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerPosition>()
            .HasKey(pp => new { pp.PlayerId, pp.PositionCode });

        modelBuilder.Entity<PlayerPosition>()
            .HasOne(pp => pp.Player)
            .WithMany(p => p.Positions)
            .HasForeignKey(pp => pp.PlayerId);

        modelBuilder.Entity<PlayerPosition>()
            .HasOne(pp => pp.Position)
            .WithMany(p => p.Players)
            .HasForeignKey(pp => pp.PositionCode);

        modelBuilder.Entity<Position>()
            .HasKey(p => p.PositionCode);

        base.OnModelCreating(modelBuilder);
    }
}
