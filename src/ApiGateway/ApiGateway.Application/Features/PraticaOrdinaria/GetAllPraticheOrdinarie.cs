using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Wrappers;
using ApiGateway.Infrastructure.Api.Clients;
using MediatR;

namespace ApiGateway.Application.Features.PraticaOrdinaria
{
    public class GetAllPraticheOrdinarie : IRequest<PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>?>
    {
        public string? SearchInput { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = int.MaxValue;
    }

    public class GetAllPraticheOrdinarieHandler(IPraticaOrdinariaClient _client)
        : IRequestHandler<GetAllPraticheOrdinarie, PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>?>
    {
        public async Task<PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>?> Handle(GetAllPraticheOrdinarie request, CancellationToken cancellationToken)
        {
            return await _client.GetPratiche(request.SearchInput, request.PageNumber, request.PageSize);
        }
    }
}
