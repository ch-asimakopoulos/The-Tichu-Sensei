using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;
using TichuSensei.Infrastructure.Identity;
using TichuSensei.Kernel.BaseModels;

namespace TichuSensei.Infrastructure.Persistence
{

    /// <summary>
    /// The applications Database context.
    /// </summary>
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        private readonly IDomainEventService _domainEventService;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService,
            IDateTime dateTime) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
            _domainEventService = domainEventService;
            _dateTime = dateTime;
        }
        /// <summary>
        /// A database set object of Tichu Sensei's players.
        /// </summary>
        public DbSet<Player> Players { get; set; }
        /// <summary>
        /// A database set object of Tichu Sensei's player statistics.
        /// </summary>
        public DbSet<PlayerStats> PlayerStats { get; set; }
        /// <summary>
        /// A database set object of Tichu Sensei's teams.
        /// </summary>
        public DbSet<Team> Teams { get; set; }
        /// <summary>
        /// A database set object of Tichu Sensei's team statistics.
        /// </summary>
        public DbSet<TeamStats> TeamStats { get; set; }
        /// <summary>
        /// A database set object of Tichu Sensei's games.
        /// </summary>
        public DbSet<Game> Games { get; set; }
        /// <summary>
        /// A database set object of Tichu Sensei's game statistics.
        /// </summary>
        public DbSet<GameStats> GameStats { get; set; }
        /// <summary>
        /// A database set object of Tichu Sensei's rounds.
        /// </summary>
        public DbSet<Round> Rounds { get; set; }
        /// <summary>
        /// A database set object of Tichu Sensei's Tichu or Grand Tichu hand calls.
        /// </summary>
        public DbSet<Call> Calls { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            int result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        private async Task DispatchEvents(CancellationToken cancellationToken)
        {
            var domainEventEntities = ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .ToArray();

            foreach (var domainEvent in domainEventEntities)
            {
                await _domainEventService.Publish(domainEvent);
            }
        }
    }


}
