using Microsoft.EntityFrameworkCore;
using PraticaOrdinaria.Application.Interfaces.Repositories;
using PraticaOrdinaria.Infrastructure.Persistence.Contexts;

namespace PraticaOrdinaria.Infrastructure.Persistence.Repositories
{
    public class PraticaOrdinariaRepositoryAsync(PraticheOrdinarieContext dbContext)
        : GenericRepositoryAsync<Domain.Entities.PraticaOrdinaria>(dbContext), IPraticaOrdinariaRepositoryAsync
    {
        private readonly DbSet<Domain.Entities.PraticaOrdinaria> _praticheOrdinarie =
            dbContext.Set<Domain.Entities.PraticaOrdinaria>();

        /// <summary>
        /// Recupero delle Pratiche Ordinarie da base dati PraticheOrdinarie
        /// </summary>
        /// <param name="pageNumber">Numero di pagina</param>
        /// <param name="pageSize">Numero di elementi per pagina</param>
        /// <returns>Lista delle Pratiche Ordinarie</returns>
        public async Task<IReadOnlyList<Domain.Entities.PraticaOrdinaria>> GetPagedReponseAsync(int pageNumber, int pageSize, string? searchInput)
        {
            var query = _praticheOrdinarie.AsQueryable();

            if (searchInput is not null and not "")
            {
                query = query.Where(x => 
                    x.Id.ToString() == searchInput ||
                    EF.Functions.Like(x.Protocollo, $"%{searchInput}%"));
            }

            return await query
                .Include(x => x.Pagamento)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Recupero delle Pratiche Ordinarie da DB PraticheOrdinarie in base al BeneficiarioId
        /// </summary>
        /// <param name="beneficiarioId">Id Beneficiario</param>
        /// <returns>Lista delle Pratiche Ordinarie</returns>
        public async Task<IReadOnlyList<Domain.Entities.PraticaOrdinaria>> GetByIdBeneficiarioAsync(Guid beneficiarioId)
        {
            return await _praticheOrdinarie
                .Include(x => x.Pagamento)
                .Where(x => x.IdBeneficiario == beneficiarioId)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Recupero della Pratica Ordinaria in base all'Id
        /// </summary>
        /// <param name="id">Id della Pratica</param>
        /// <returns>La Pratica Ordinaria</returns>
        public override async Task<Domain.Entities.PraticaOrdinaria?> GetByIdAsync(Guid id)
        {
            return await _praticheOrdinarie
                .Include(x => x.Pagamento)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Conta il numero di Pratiche Ordinarie
        /// </summary>
        /// <returns>Numero di Pratiche Ordinarie</returns>
        public async Task<int> CountAsync()
        {
            return await _praticheOrdinarie
                .CountAsync();
        }
    }
}
