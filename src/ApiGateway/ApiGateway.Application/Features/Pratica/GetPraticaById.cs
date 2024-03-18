using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Wrappers;
using ApiGateway.Infrastructure.Api.Clients;
using MediatR;

namespace ApiGateway.Application.Features.Pratica
{
    public class GetPraticaById : IRequest<Response<PraticaViewModel>>
    {
        public Guid Id { get; set; }
    }

    public class GetPraticaByIdHandler(
            IPraticaOrdinariaClient praticaOrdinariaClient,
            IPraticaStraordinariaClient praticaStraordinariaClient
        )
        : IRequestHandler<GetPraticaById, Response<PraticaViewModel>>
    {
        public async Task<Response<PraticaViewModel>> Handle(GetPraticaById request, CancellationToken cancellationToken)
        {
            var (task1, task2) = (
                praticaOrdinariaClient.GetPraticaById(request.Id),
                praticaStraordinariaClient.GetPraticaById(request.Id)
            );

            await Task.WhenAll(task1, task2);

            if (task1.Result?.Data is not null)
            {
                return new Response<PraticaViewModel>(task1.Result.Data);
            }
            else if (task2.Result?.Data is not null)
            {
                return new Response<PraticaViewModel>(task2.Result.Data);
            }

            return new Response<PraticaViewModel>(null, "Pratica non trovata.");
        }
    }
}
