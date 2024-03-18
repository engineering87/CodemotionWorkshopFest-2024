using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Wrappers;
using ApiGateway.Infrastructure.Api.Clients;
using MediatR;

namespace ApiGateway.Application.Features.Beneficiario
{
    public class GetBeneficiarioById : IRequest<Response<BeneficiarioViewModel>?>
    {
        public Guid Id { get; set; }
    }

    public class GetBeneficiarioByIdHandler(IBeneficiarioClient client)
        : IRequestHandler<GetBeneficiarioById, Response<BeneficiarioViewModel>?>
    {
        public async Task<Response<BeneficiarioViewModel>?> Handle(GetBeneficiarioById request, CancellationToken cancellationToken)
        {
            return await client.GetBeneficiarioById(request.Id);
        }
    }
}
