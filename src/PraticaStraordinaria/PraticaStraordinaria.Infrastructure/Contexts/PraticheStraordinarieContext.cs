using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace PraticaStraordinaria.Infrastructure.Persistence.Contexts
{
    public class PraticheStraordinarieContext : DbContext
    {
        public PraticheStraordinarieContext(DbContextOptions<PraticheStraordinarieContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Domain.Entities.PraticaStraordinaria> PraticheStraordinarie { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Domain.Entities.PraticaStraordinaria>()
                .HasKey(p => p.Id);

            builder.Entity<Domain.Entities.PraticaStraordinaria>()
                .HasOne(p => p.Causale)
                .WithMany()
                .HasForeignKey(p => p.IdCausale);
        }
    }
}
