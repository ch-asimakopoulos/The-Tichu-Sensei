using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Shared.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStats> PlayerStats { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamStats> TeamStats { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameStats> GameStats { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Call> Calls { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
