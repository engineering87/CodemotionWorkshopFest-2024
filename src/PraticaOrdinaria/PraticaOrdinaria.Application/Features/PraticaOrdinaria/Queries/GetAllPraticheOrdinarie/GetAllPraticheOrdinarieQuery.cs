using PraticaOrdinaria.Application.Wrappers;
using MediatR;
using AutoMapper;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.ViewModels;
using PraticaOrdinaria.Application.Interfaces.Repositories;

namespace PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.GetAllPraticheOrdinarie
{
    public class GetAllPraticheOrdinarieQuery : IRequest<PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>>
    {
        public string? SearchInput { get; set; } = string.Empty;
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = int.MaxValue;
    }

    public class GetAllPraticheOrdinarieQueryHandler(IPraticaOrdinariaRepositoryAsync praticheOrdinarieRepository, IMapper mapper)
        : IRequestHandler<GetAllPraticheOrdinarieQuery, PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>>
    {
        private readonly IPraticaOrdinariaRepositoryAsync _praticheOrdinarieRepository = praticheOrdinarieRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>> Handle(GetAllPraticheOrdinarieQuery request, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Ordinarie viene iniettato nel costruttore primario
            // Vengono recuperate le Pratiche in base ai filtri di paginazione
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione delle Pratiche

            var validFilter = _mapper.Map<GetAllPraticheOrdinarieParameter>(request);
            var pratiche = await _praticheOrdinarieRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize, validFilter.SearchInput);
            var praticheViewModel = _mapper.Map<IEnumerable<PraticaOrdinariaViewModel>>(pratiche);
            return new PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>(praticheViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
