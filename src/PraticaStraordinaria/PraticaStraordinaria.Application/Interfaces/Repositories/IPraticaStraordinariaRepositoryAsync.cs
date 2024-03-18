namespace PraticaStraordinaria.Application.Interfaces.Repositories
{
    public interface IPraticaStraordinariaRepositoryAsync : IGenericRepositoryAsync<Domain.Entities.PraticaStraordinaria>
    {
        Task<int> CountAsync();
        Task<IReadOnlyList<Domain.Entities.PraticaStraordinaria>> GetByIdBeneficiarioAsync(Guid beneficiarioId);
        Task<IReadOnlyList<Domain.Entities.PraticaStraordinaria>> GetPagedReponseAsync(int pageNumber, int pageSize, string? searchInput);
    }
}
