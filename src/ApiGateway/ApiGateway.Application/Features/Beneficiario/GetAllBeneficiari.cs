using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Wrappers;
using ApiGateway.Infrastructure.Api.Clients;
using MediatR;

namespace ApiGateway.Application.Features.Beneficiario
{
    public class GetAllBeneficiari : IRequest<PagedResponse<IEnumerable<BeneficiarioViewModel>>?>
    {
        public string? SearchInput { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = int.MaxValue;
    }

    public class GetAllBeneficiariHandler(IBeneficiarioClient _client)
        : IRequestHandler<GetAllBeneficiari, PagedResponse<IEnumerable<BeneficiarioViewModel>>?>
    {
        public async Task<PagedResponse<IEnumerable<BeneficiarioViewModel>>?> Handle(GetAllBeneficiari request, CancellationToken cancellationToken)
        {
            return await _client.GetBeneficiari(request.SearchInput, request.PageNumber, request.PageSize);
        }
    }
}
