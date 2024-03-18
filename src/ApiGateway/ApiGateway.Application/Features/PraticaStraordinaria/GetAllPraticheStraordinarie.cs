using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Wrappers;
using ApiGateway.Infrastructure.Api.Clients;
using MediatR;

namespace ApiGateway.Application.Features.PraticaStraordinaria
{
    public class GetAllPraticheStraordinarie : IRequest<PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>?>
    {
        public string? SearchInput { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = int.MaxValue;
    }

    public class GetAllPraticheStraordinarieHandler(IPraticaStraordinariaClient _client)
        : IRequestHandler<GetAllPraticheStraordinarie, PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>?>
    {
        public async Task<PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>?> Handle(GetAllPraticheStraordinarie request, CancellationToken cancellationToken)
        {
            return await _client.GetPratiche(request.SearchInput, request.PageNumber, request.PageSize);
        }
    }
}
