using Beneficiari.Application.Interfaces.Repositories;
using Beneficiari.Domain.Entities;
using Beneficiari.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Beneficiari.Infrastructure.Persistence.Repositories
{
    public class BeneficiariRepositoryAsync(BeneficiariContext dbContext)
        : GenericRepositoryAsync<Beneficiario>(dbContext), IBeneficiariRepositoryAsync
    {
        private readonly DbSet<Beneficiario> _beneficiari = dbContext.Set<Beneficiario>();

        public async Task<IReadOnlyList<Beneficiario>> GetPagedReponseAsync(int pageNumber, int pageSize, string? searchInput)
        {
            var query = _beneficiari.AsQueryable();

            if (searchInput is not null and not "")
            {
                query = query.Where(x =>
                    EF.Functions.Like(x.Cognome, $"%{searchInput}%") ||
                    EF.Functions.Like(x.Email, $"%{searchInput}%"));
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
