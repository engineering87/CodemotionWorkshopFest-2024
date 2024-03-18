using AutoMapper;
using MediatR;
using PraticaStraordinaria.Application.Exceptions;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.ViewModels;
using PraticaStraordinaria.Application.Interfaces.Repositories;
using PraticaStraordinaria.Application.Wrappers;

namespace PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.GetPraticaStraordinariaById
{
    public class GetPraticaStraordinariaByIdQuery : IRequest<Response<PraticaStraordinariaViewModel>>
    {
        public Guid Id { get; set; }
    }

    public class GetPraticaStraordinariaByIdQueryHandler(IPraticaStraordinariaRepositoryAsync praticheStraordinarieRepository, IMapper mapper)
        : IRequestHandler<GetPraticaStraordinariaByIdQuery, Response<PraticaStraordinariaViewModel>>
    {
        private readonly IPraticaStraordinariaRepositoryAsync _praticheStraordinarieRepository = praticheStraordinarieRepository;
        private readonly IMapper _mapper = mapper;
    
        public async Task<Response<PraticaStraordinariaViewModel>> Handle(GetPraticaStraordinariaByIdQuery query, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Straordinarie viene iniettato nel costruttore primario
            // Viene recuperata la pratica in base all'Id specificato
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione delle Pratiche
    
            var pratica = await _praticheStraordinarieRepository.GetByIdAsync(query.Id) 
                ?? throw new ApiException($"Pratica non trovata.");
    
            var praticaViewModel = _mapper.Map<PraticaStraordinariaViewModel>(pratica);
            return new Response<PraticaStraordinariaViewModel>(praticaViewModel);
        }
    }
}