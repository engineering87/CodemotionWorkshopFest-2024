using AutoMapper;
using Beneficiari.Application.Features.Beneficiari.ViewModels;
using Beneficiari.Application.Interfaces.Repositories;
using Beneficiari.Application.Wrappers;
using MediatR;

namespace Beneficiari.Application.Features.Beneficiari.Queries.GetAllBeneficiari
{
    public class GetAllBeneficiariQuery : IRequest<PagedResponse<IEnumerable<BeneficiarioViewModel>>>
    {
        public string? SearchInput { get; set; } = string.Empty;
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = int.MaxValue;
    }

    public class GetAllBeneficiariQueryHandler(IBeneficiariRepositoryAsync beneficiariRepository, IMapper mapper)
        : IRequestHandler<GetAllBeneficiariQuery, PagedResponse<IEnumerable<BeneficiarioViewModel>>>
    {
        private readonly IBeneficiariRepositoryAsync _beneficiariRepository = beneficiariRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PagedResponse<IEnumerable<BeneficiarioViewModel>>> Handle(GetAllBeneficiariQuery request, CancellationToken cancellationToken)
        {
            // Il repository specializzato per i Beneficiari viene iniettato nel costruttore primario
            // Vengono recuperati i Beneficiari in base ai filtri di paginazione
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione dei Beneficiari

            var validFilter = _mapper.Map<GetAllBeneficiariParameter>(request);
            var beneficiari = await _beneficiariRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize, validFilter.SearchInput);
            var beneficiariViewModel = _mapper.Map<IEnumerable<BeneficiarioViewModel>>(beneficiari);
            return new PagedResponse<IEnumerable<BeneficiarioViewModel>>(beneficiariViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
