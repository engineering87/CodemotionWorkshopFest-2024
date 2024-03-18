using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace PraticaOrdinaria.Infrastructure.Persistence.Contexts
{
    public class PraticheOrdinarieContext : DbContext
    {
        public PraticheOrdinarieContext(DbContextOptions<PraticheOrdinarieContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Domain.Entities.PraticaOrdinaria> PraticheOrdinarie { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Domain.Entities.PraticaOrdinaria>()
                .HasKey(p => p.Id);

            builder.Entity<Domain.Entities.PraticaOrdinaria>()
                .HasOne(p => p.Pagamento)
                .WithMany()
                .HasForeignKey(p => p.TipoPagamento);
        }
    }
}
