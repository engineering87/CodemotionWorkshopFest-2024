using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using PraticaStraordinaria.Domain.Entities.Legacy;

namespace PraticaStraordinaria.Infrastructure.Persistence.Contexts
{
    public class PraticheLegacyContext : DbContext
    {
        public PraticheLegacyContext(DbContextOptions<PraticheLegacyContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<PraticaLegacy> Pratiche { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PraticaLegacy>()
                .HasKey(p => p.P_GUID);

            builder.Entity<PraticaLegacy>()
                .HasOne(p => p.Causali)
                .WithMany()
                .HasForeignKey(p => p.P_CAU);
        }
    }
}
