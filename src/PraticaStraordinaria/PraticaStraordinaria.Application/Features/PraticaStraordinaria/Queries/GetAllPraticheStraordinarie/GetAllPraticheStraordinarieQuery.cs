using PraticaStraordinaria.Application.Wrappers;
using MediatR;
using AutoMapper;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.ViewModels;
using PraticaStraordinaria.Application.Interfaces.Repositories;

namespace PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.GetAllPraticheStraordinarie
{
    public class GetAllPraticheStraordinarieQuery : IRequest<PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>>
    {
        public string? SearchInput { get; set; } = string.Empty;
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = int.MaxValue;
    }

    public class GetAllPraticheStraordinarieQueryHandler(IPraticaStraordinariaRepositoryAsync praticheStraordinarieRepository, IMapper mapper)
        : IRequestHandler<GetAllPraticheStraordinarieQuery, PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>>
    {
        private readonly IPraticaStraordinariaRepositoryAsync _praticheStraordinarieRepository = praticheStraordinarieRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>> Handle(GetAllPraticheStraordinarieQuery request, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Straordinarie viene iniettato nel costruttore primario
            // Vengono recuperate le Pratiche in base ai filtri di paginazione
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione delle Pratiche

            var validFilter = _mapper.Map<GetAllPraticheStraordinarieParameter>(request);
            var pratiche = await _praticheStraordinarieRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize, validFilter.SearchInput);
            var praticheViewModel = _mapper.Map<IEnumerable<PraticaStraordinariaViewModel>>(pratiche);
            return new PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>(praticheViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
