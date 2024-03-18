using AutoMapper;
using MediatR;
using PraticaOrdinaria.Application.Exceptions;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.ViewModels;
using PraticaOrdinaria.Application.Interfaces.Repositories;
using PraticaOrdinaria.Application.Wrappers;

namespace PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.GetPraticaOrdinariaById
{
    public class GetPraticaOrdinariaByIdQuery : IRequest<Response<PraticaOrdinariaViewModel>>
    {
        public Guid Id { get; set; }
    }

    public class GetPraticaOrdinariaByIdQueryHandler(IPraticaOrdinariaRepositoryAsync praticheOrdinarieRepository, IMapper mapper)
        : IRequestHandler<GetPraticaOrdinariaByIdQuery, Response<PraticaOrdinariaViewModel>>
    {
        private readonly IPraticaOrdinariaRepositoryAsync _praticheOrdinarieRepository = praticheOrdinarieRepository;
        private readonly IMapper _mapper = mapper;
    
        public async Task<Response<PraticaOrdinariaViewModel>> Handle(GetPraticaOrdinariaByIdQuery query, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Ordinarie viene iniettato nel costruttore primario
            // Viene recuperata la pratica in base all'Id specificato
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione delle Pratiche
    
            var pratica = await _praticheOrdinarieRepository.GetByIdAsync(query.Id) 
                ?? throw new ApiException($"Pratica non trovata.");
    
            var praticaViewModel = _mapper.Map<PraticaOrdinariaViewModel>(pratica);
            return new Response<PraticaOrdinariaViewModel>(praticaViewModel);
        }
    }
}