using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using footballstats.Models;

namespace footballstats.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<GameRecord> Record { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Referee> Referee { get; set; }
        public DbSet<ChangeRecord> ChangeRecord { get; set; }
        public DbSet<Change> Change { get; set; }
        public DbSet<GoalsList> GoalsList { get; set; }
        public DbSet<Goal> Goal { get; set; }
        public DbSet<PenaltiesList> PenaltiesList { get; set; }
        public DbSet<Penalty> Penalty { get; set; }
        public DbSet<PlayersNrList> PlayersNrList { get; set; }
        public DbSet<PlayersNr> PlayersNr { get; set; }
        public DbSet<PlayersList> PlayersList { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<DomainTeam> DomainTeam { get; set; }
    }
}
