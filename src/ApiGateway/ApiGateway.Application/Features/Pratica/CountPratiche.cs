using ApiGateway.Application.Wrappers;
using ApiGateway.Domain.DTOs;
using ApiGateway.Infrastructure.Api.Clients;
using MediatR;

namespace ApiGateway.Application.Features.Pratica
{
    public class CountPratiche : IRequest<Response<ContatoriPratiche>>
    {
    }

    public class CountPraticheHandler(
            IPraticaOrdinariaClient praticaOrdinariaClient,
            IPraticaStraordinariaClient praticaStraordinariaClient
        ) : IRequestHandler<CountPratiche, Response<ContatoriPratiche>>
    {
        public async Task<Response<ContatoriPratiche>> Handle(CountPratiche request, CancellationToken cancellationToken)
        {
            var (task1, task2) = (
                praticaOrdinariaClient.CountPratiche(),
                praticaStraordinariaClient.CountPratiche()
            );

            await Task.WhenAll(task1, task2);

            var result = new ContatoriPratiche()
            {
                ContatorePraticheOrdinarie = task1.Result?.Data ?? 0,
                ContatorePraticheStraordinarie = task2.Result?.Data ?? 0
            };

            return new Response<ContatoriPratiche>(result);
        }
    }
}
