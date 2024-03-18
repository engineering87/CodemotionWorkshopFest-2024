using AutoMapper;
using MediatR;
using PraticaStraordinaria.Application.Exceptions;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.ViewModels;
using PraticaStraordinaria.Application.Interfaces.Repositories;
using PraticaStraordinaria.Application.Wrappers;

namespace PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.GetPraticaStraordinariaById
{
    public class GetPraticaStraordinariaByIdQueryLegacy : IRequest<Response<PraticaStraordinariaViewModel>>
    {
        public Guid Id { get; set; }
    }

    public class GetPraticaStraordinariaByIdQueryLegacyHandler(IPraticaLegacyRepositoryAsync praticaLegacyRepository, IMapper mapper)
        : IRequestHandler<GetPraticaStraordinariaByIdQueryLegacy, Response<PraticaStraordinariaViewModel>>
    {
        private readonly IPraticaLegacyRepositoryAsync _praticaLegacyRepository = praticaLegacyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<PraticaStraordinariaViewModel>> Handle(GetPraticaStraordinariaByIdQueryLegacy query, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Legacy viene iniettato nel costruttore primario
            // Viene recuperata la pratica in base all'Id specificato
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione delle Pratiche

            var pratica = await _praticaLegacyRepository.GetByIdAsync(query.Id)
                ?? throw new ApiException($"Pratica non trovata.");

            var praticaViewModel = _mapper.Map<PraticaStraordinariaViewModel>(pratica);
            return new Response<PraticaStraordinariaViewModel>(praticaViewModel);
        }
    }
}