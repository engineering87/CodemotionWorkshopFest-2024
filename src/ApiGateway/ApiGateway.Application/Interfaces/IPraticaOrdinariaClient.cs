
using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Wrappers;

namespace ApiGateway.Infrastructure.Api.Clients
{
    public interface IPraticaOrdinariaClient
    {
        Task<Response<int>?> CountPratiche();
        Task<Response<PraticaOrdinariaViewModel>?> GetPraticaById(Guid id);
        Task<PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>?> GetPratiche(string? searchInput, int? pageNumber = null, int? pageSize = null);
        Task<Response<IEnumerable<PraticaOrdinariaViewModel>>?> GetPraticheByBeneficiarioId(Guid beneficiarioId);
    }
}