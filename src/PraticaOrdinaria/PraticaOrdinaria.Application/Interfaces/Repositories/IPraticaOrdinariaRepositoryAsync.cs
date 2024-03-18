namespace PraticaOrdinaria.Application.Interfaces.Repositories
{
    public interface IPraticaOrdinariaRepositoryAsync : IGenericRepositoryAsync<Domain.Entities.PraticaOrdinaria>
    {
        Task<int> CountAsync();
        Task<IReadOnlyList<Domain.Entities.PraticaOrdinaria>> GetByIdBeneficiarioAsync(Guid beneficiarioId);
        Task<IReadOnlyList<Domain.Entities.PraticaOrdinaria>> GetPagedReponseAsync(int pageNumber, int pageSize, string? searchInput);
    }
}
