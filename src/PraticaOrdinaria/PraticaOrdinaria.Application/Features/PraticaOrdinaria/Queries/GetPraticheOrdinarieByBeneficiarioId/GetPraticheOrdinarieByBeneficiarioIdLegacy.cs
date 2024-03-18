using AutoMapper;
using MediatR;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.ViewModels;
using PraticaOrdinaria.Application.Interfaces.Repositories;
using PraticaOrdinaria.Application.Wrappers;

namespace PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.GetPraticaOrdinariaById
{
    public class GetPraticheOrdinarieByBeneficiarioIdLegacy : IRequest<Response<IEnumerable<PraticaOrdinariaViewModel>>>
    {
        public Guid Id { get; set; }
    }

    public class GetPraticheOrdinarieByBeneficiarioIdLegacyHandler(IPraticaLegacyRepositoryAsync praticheLegacyRepository, IMapper mapper)
        : IRequestHandler<GetPraticheOrdinarieByBeneficiarioIdLegacy, Response<IEnumerable<PraticaOrdinariaViewModel>>>
    {
        private readonly IPraticaLegacyRepositoryAsync _praticheLegacyRepository = praticheLegacyRepository;
        private readonly IMapper _mapper = mapper;
    
        public async Task<Response<IEnumerable<PraticaOrdinariaViewModel>>> Handle(GetPraticheOrdinarieByBeneficiarioIdLegacy query, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Ordinarie viene iniettato nel costruttore primario
            // Viene recuperata la pratica in base all'IdBeneficiario specificato
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione delle Pratiche

            var pratiche = await _praticheLegacyRepository.GetByIdBeneficiarioAsync(query.Id);
            var praticheViewModel = _mapper.Map<IEnumerable<PraticaOrdinariaViewModel>>(pratiche);
            return new Response<IEnumerable<PraticaOrdinariaViewModel>>(praticheViewModel);
        }
    }
}