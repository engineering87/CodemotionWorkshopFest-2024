
using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Wrappers;

namespace ApiGateway.Infrastructure.Api.Clients
{
    public interface IPraticaStraordinariaClient
    {
        Task<Response<int>?> CountPratiche();
        Task<Response<PraticaStraordinariaViewModel>?> GetPraticaById(Guid id);
        Task<PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>?> GetPratiche(string? searchInput, int? pageNumber = null, int? pageSize = null);
        Task<Response<IEnumerable<PraticaStraordinariaViewModel>>?> GetPraticheByBeneficiarioId(Guid beneficiarioId);
    }
}