using PraticaOrdinaria.Domain.Entities.Legacy;

namespace PraticaOrdinaria.Application.Interfaces.Repositories
{
    public interface IPraticaLegacyRepositoryAsync : IGenericRepositoryAsync<PraticaLegacy>
    {
        Task<int> CountAsync();
        Task<IReadOnlyList<PraticaLegacy>> GetByIdBeneficiarioAsync(Guid beneficiarioId);
        Task<IReadOnlyList<PraticaLegacy>> GetPagedReponseAsync(int pageNumber, int pageSize, string? searchInput);
    }
}
