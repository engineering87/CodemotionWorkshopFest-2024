using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Wrappers;
using ApiGateway.Infrastructure.Api.Clients;
using MediatR;

namespace ApiGateway.Application.Features.Pratica
{
    public class GetPraticheByBeneficiarioId : IRequest<Response<IEnumerable<PraticaViewModel>>>
    {
        public Guid Id { get; set; }
    }

    public class GetPraticheByBeneficiarioIdHandler(
            IPraticaOrdinariaClient praticaOrdinariaClient,
            IPraticaStraordinariaClient praticaStraordinariaClient
        )
        : IRequestHandler<GetPraticheByBeneficiarioId, Response<IEnumerable<PraticaViewModel>>>
    {
        public async Task<Response<IEnumerable<PraticaViewModel>>> Handle(GetPraticheByBeneficiarioId request, CancellationToken cancellationToken)
        {
            var (task1, task2) = (
                praticaOrdinariaClient.GetPraticheByBeneficiarioId(request.Id),
                praticaStraordinariaClient.GetPraticheByBeneficiarioId(request.Id)
            );

            await Task.WhenAll(task1, task2);

            var result = new List<PraticaViewModel>();

            result.AddRange(task1.Result?.Data ?? Enumerable.Empty<PraticaViewModel>());
            result.AddRange(task2.Result?.Data ?? Enumerable.Empty<PraticaViewModel>());

            return new Response<IEnumerable<PraticaViewModel>>(result);
        }
    }
}
