using AutoMapper;
using Beneficiari.Application.Exceptions;
using Beneficiari.Application.Features.Beneficiari.ViewModels;
using Beneficiari.Application.Interfaces.Repositories;
using Beneficiari.Application.Wrappers;
using MediatR;

namespace Beneficiari.Application.Features.Beneficiari.Queries.GetBeneficiarioById
{
    public class GetBeneficiarioByIdQuery : IRequest<Response<BeneficiarioViewModel>>
    {
        public Guid Id { get; set; }
    }

    public class GetBeneficiarioByIdQueryHandler(IBeneficiariRepositoryAsync beneficiariRepository, IMapper mapper)
        : IRequestHandler<GetBeneficiarioByIdQuery, Response<BeneficiarioViewModel>>
    {
        private readonly IBeneficiariRepositoryAsync _beneficiariRepository = beneficiariRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<BeneficiarioViewModel>> Handle(GetBeneficiarioByIdQuery query, CancellationToken cancellationToken)
        {
            // Il repository specializzato per i Beneficiari viene iniettato nel costruttore primario
            // Viene recuperato il Beneficiario in base all'Id specificato
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione dei Beneficiari

            var beneficiario = await _beneficiariRepository.GetByIdAsync(query.Id)
                ?? throw new ApiException($"Beneficiario non trovato.");

            var beneficiarioViewModel = _mapper.Map<BeneficiarioViewModel>(beneficiario);
            return new Response<BeneficiarioViewModel>(beneficiarioViewModel);
        }
    }
}
