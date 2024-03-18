using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Beneficiari.Domain.Entities;

namespace Beneficiari.Infrastructure.Persistence.Contexts
{
    public class BeneficiariContext : DbContext
    {
        public BeneficiariContext(DbContextOptions<BeneficiariContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Beneficiario> Beneficiari { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Beneficiario>()
                .HasKey(p => p.Id);
        }
    }
}
