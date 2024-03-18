using Beneficiari.Domain.Entities;

namespace Beneficiari.Application.Interfaces.Repositories
{
    public interface IBeneficiariRepositoryAsync : IGenericRepositoryAsync<Beneficiario>
    {
        Task<IReadOnlyList<Beneficiario>> GetPagedReponseAsync(int pageNumber, int pageSize, string? searchInput);
    }
}
