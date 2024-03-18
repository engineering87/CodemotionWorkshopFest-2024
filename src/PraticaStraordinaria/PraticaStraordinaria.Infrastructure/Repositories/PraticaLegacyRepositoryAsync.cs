using Microsoft.EntityFrameworkCore;
using PraticaStraordinaria.Domain.Enums;
using PraticaStraordinaria.Application.Interfaces.Repositories;
using PraticaStraordinaria.Domain.Entities.Legacy;
using PraticaStraordinaria.Infrastructure.Persistence.Contexts;

namespace PraticaStraordinaria.Infrastructure.Persistence.Repositories
{
    public class PraticaLegacyRepositoryAsync(PraticheLegacyContext dbContext)
        : GenericRepositoryAsync<PraticaLegacy>(dbContext), IPraticaLegacyRepositoryAsync
    {
        private readonly DbSet<PraticaLegacy> _praticheLegacy = dbContext.Set<PraticaLegacy>();

        /// <summary>
        /// Recupero delle Pratiche Straordinarie da base dati Legacy
        /// </summary>
        /// <param name="pageNumber">Numero di pagina</param>
        /// <param name="pageSize">Numero di elementi per pagina</param>
        /// <returns>Lista delle Pratiche Straordinarie</returns>
        public async Task<IReadOnlyList<PraticaLegacy>> GetPagedReponseAsync(int pageNumber, int pageSize, string? searchInput)
        {
            var query = _praticheLegacy.AsQueryable();

            if (searchInput is not null and not "")
            {
                query = query.Where(x =>
                    x.P_GUID.ToString() == searchInput ||
                    EF.Functions.Like(x.P_PTC, $"%{searchInput}%"));
            }

            return await query
                .Where(x => x.P_TYPE == (int)TipoPraticaEnum.Straordinaria)
                .Include(x => x.Causali)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Recupero delle Pratiche Straordinarie da DB Legacy in base al BeneficiarioId
        /// </summary>
        /// <param name="beneficiarioId">Id Beneficiario</param>
        /// <returns>Lista delle Pratiche Straordinarie</returns>
        public async Task<IReadOnlyList<PraticaLegacy>> GetByIdBeneficiarioAsync(Guid beneficiarioId)
        {
            return await _praticheLegacy
                .Include(x => x.Causali)
                .Where(x => 
                    x.P_TYPE == (int)TipoPraticaEnum.Straordinaria &&
                    x.BEN_GUID == beneficiarioId)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Recupero della Pratica Straordinaria in base all'Id
        /// </summary>
        /// <param name="id">Id della Pratica</param>
        /// <returns>La Pratica Straordinaria</returns>
        public override async Task<PraticaLegacy?> GetByIdAsync(Guid id)
        {
            return await _praticheLegacy
                .Include(x => x.Causali)
                .FirstOrDefaultAsync(x => x.P_GUID == id);
        }

        /// <summary>
        /// Conta il numero di Pratiche Straordinarie
        /// </summary>
        /// <returns>Numero di Pratiche Straordinarie</returns>
        public async Task<int> CountAsync()
        {
            return await _praticheLegacy
                .Where(x => x.P_TYPE == (int)TipoPraticaEnum.Straordinaria)
                .CountAsync();
        }
    }
}
