
using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Wrappers;

namespace ApiGateway.Infrastructure.Api.Clients
{
    public interface IBeneficiarioClient
    {
        Task<Response<BeneficiarioViewModel>?> GetBeneficiarioById(Guid id);
        Task<PagedResponse<IEnumerable<BeneficiarioViewModel>>?> GetBeneficiari(string? searchInput, int? pageNumber = null, int? pageSize = null);
    }
}