using AutoMapper;
using MediatR;
using PraticaOrdinaria.Application.Exceptions;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.ViewModels;
using PraticaOrdinaria.Application.Interfaces.Repositories;
using PraticaOrdinaria.Application.Wrappers;

namespace PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.GetPraticaOrdinariaById
{
    public class GetPraticaOrdinariaByIdQueryLegacy : IRequest<Response<PraticaOrdinariaViewModel>>
    {
        public Guid Id { get; set; }
    }

    public class GetPraticaOrdinariaByIdQueryLegacyHandler(IPraticaLegacyRepositoryAsync praticaLegacyRepository, IMapper mapper)
        : IRequestHandler<GetPraticaOrdinariaByIdQueryLegacy, Response<PraticaOrdinariaViewModel>>
    {
        private readonly IPraticaLegacyRepositoryAsync _praticaLegacyRepository = praticaLegacyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<PraticaOrdinariaViewModel>> Handle(GetPraticaOrdinariaByIdQueryLegacy query, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Legacy viene iniettato nel costruttore primario
            // Viene recuperata la pratica in base all'Id specificato
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione delle Pratiche

            var pratica = await _praticaLegacyRepository.GetByIdAsync(query.Id)
                ?? throw new ApiException($"Pratica non trovata.");

            var praticaViewModel = _mapper.Map<PraticaOrdinariaViewModel>(pratica);
            return new Response<PraticaOrdinariaViewModel>(praticaViewModel);
        }
    }
}