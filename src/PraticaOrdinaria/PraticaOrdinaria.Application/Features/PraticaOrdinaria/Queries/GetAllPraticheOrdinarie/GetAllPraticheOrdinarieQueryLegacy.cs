using PraticaOrdinaria.Application.Wrappers;
using MediatR;
using AutoMapper;
using PraticaOrdinaria.Application.Interfaces.Repositories;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.ViewModels;

namespace PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.GetAllPraticheOrdinarie
{
    public class GetAllPraticheOrdinarieQueryLegacy : IRequest<PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>>
    {
        public string? SearchInput { get; set; } = string.Empty;
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = int.MaxValue;
    }

    public class GetAllPraticheOrdinarieQueryLegacyHandler(IPraticaLegacyRepositoryAsync praticaLegacyRepository, IMapper mapper)
        : IRequestHandler<GetAllPraticheOrdinarieQueryLegacy, PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>>
    {
        private readonly IPraticaLegacyRepositoryAsync _praticaLegacyRepository = praticaLegacyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>> Handle(GetAllPraticheOrdinarieQueryLegacy request, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Legacy viene iniettato nel costruttore primario
            // Vengono recuperate le sole Pratiche Ordinarie, in base ai filtri di paginazione
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione delle Pratiche

            var validFilter = _mapper.Map<GetAllPraticheOrdinarieParameter>(request);
            var pratiche = await _praticaLegacyRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize, validFilter.SearchInput);
            var praticheViewModel = _mapper.Map<IEnumerable<PraticaOrdinariaViewModel>>(pratiche);
            return new PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>(praticheViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
