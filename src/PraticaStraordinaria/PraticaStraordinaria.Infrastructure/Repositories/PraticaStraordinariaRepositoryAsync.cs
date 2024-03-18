using Microsoft.EntityFrameworkCore;
using PraticaStraordinaria.Application.Interfaces.Repositories;
using PraticaStraordinaria.Infrastructure.Persistence.Contexts;

namespace PraticaStraordinaria.Infrastructure.Persistence.Repositories
{
    public class PraticaStraordinariaRepositoryAsync(PraticheStraordinarieContext dbContext)
        : GenericRepositoryAsync<Domain.Entities.PraticaStraordinaria>(dbContext), IPraticaStraordinariaRepositoryAsync
    {
        private readonly DbSet<Domain.Entities.PraticaStraordinaria> _praticheStraordinarie =
            dbContext.Set<Domain.Entities.PraticaStraordinaria>();

        /// <summary>
        /// Recupero delle Pratiche Straordinarie da base dati PraticheStraordinarie
        /// </summary>
        /// <param name="pageNumber">Numero di pagina</param>
        /// <param name="pageSize">Numero di elementi per pagina</param>
        /// <returns>Lista delle Pratiche Straordinarie</returns>
        public async Task<IReadOnlyList<Domain.Entities.PraticaStraordinaria>> GetPagedReponseAsync(int pageNumber, int pageSize, string? searchInput)
        {
            var query = _praticheStraordinarie.AsQueryable();

            if (searchInput is not null and not "")
            {
                query = query.Where(x => 
                    x.Id.ToString() == searchInput ||
                    EF.Functions.Like(x.Protocollo, $"%{searchInput}%"));
            }

            return await query
                .Include(x => x.Causale)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Recupero delle Pratiche Straordinarie da DB PraticheStraordinarie in base al BeneficiarioId
        /// </summary>
        /// <param name="beneficiarioId">Id Beneficiario</param>
        /// <returns>Lista delle Pratiche Straordinarie</returns>
        public async Task<IReadOnlyList<Domain.Entities.PraticaStraordinaria>> GetByIdBeneficiarioAsync(Guid beneficiarioId)
        {
            return await _praticheStraordinarie
                .Include(x => x.Causale)
                .Where(x => x.IdBeneficiario == beneficiarioId)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Recupero della Pratica Straordinaria in base all'Id
        /// </summary>
        /// <param name="id">Id della Pratica</param>
        /// <returns>La Pratica Straordinaria</returns>
        public override async Task<Domain.Entities.PraticaStraordinaria?> GetByIdAsync(Guid id)
        {
            return await _praticheStraordinarie
                .Include(x => x.Causale)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Conta il numero di Pratiche Straordinarie
        /// </summary>
        /// <returns>Numero di Pratiche Straordinarie</returns>
        public async Task<int> CountAsync()
        {
            return await _praticheStraordinarie
                .CountAsync();
        }
    }
}
