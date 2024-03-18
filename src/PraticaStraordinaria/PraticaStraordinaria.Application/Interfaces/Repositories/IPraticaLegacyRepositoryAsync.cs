using PraticaStraordinaria.Domain.Entities.Legacy;

namespace PraticaStraordinaria.Application.Interfaces.Repositories
{
    public interface IPraticaLegacyRepositoryAsync : IGenericRepositoryAsync<PraticaLegacy>
    {
        Task<int> CountAsync();
        Task<IReadOnlyList<PraticaLegacy>> GetByIdBeneficiarioAsync(Guid beneficiarioId);
        Task<IReadOnlyList<PraticaLegacy>> GetPagedReponseAsync(int pageNumber, int pageSize, string? searchInput);
    }
}
