using PraticaStraordinaria.Application.Wrappers;
using MediatR;
using AutoMapper;
using PraticaStraordinaria.Application.Interfaces.Repositories;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.ViewModels;

namespace PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.GetAllPraticheStraordinarie
{
    public class GetAllPraticheStraordinarieQueryLegacy : IRequest<PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>>
    {
        public string? SearchInput { get; set; } = string.Empty;
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = int.MaxValue;
    }

    public class GetAllPraticheStraordinarieQueryLegacyHandler(IPraticaLegacyRepositoryAsync praticaLegacyRepository, IMapper mapper)
        : IRequestHandler<GetAllPraticheStraordinarieQueryLegacy, PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>>
    {
        private readonly IPraticaLegacyRepositoryAsync _praticaLegacyRepository = praticaLegacyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>> Handle(GetAllPraticheStraordinarieQueryLegacy request, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Legacy viene iniettato nel costruttore primario
            // Vengono recuperate le sole Pratiche Straordinarie, in base ai filtri di paginazione
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione delle Pratiche

            var validFilter = _mapper.Map<GetAllPraticheStraordinarieParameter>(request);
            var pratiche = await _praticaLegacyRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize, validFilter.SearchInput);
            var praticheViewModel = _mapper.Map<IEnumerable<PraticaStraordinariaViewModel>>(pratiche);
            return new PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>(praticheViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
