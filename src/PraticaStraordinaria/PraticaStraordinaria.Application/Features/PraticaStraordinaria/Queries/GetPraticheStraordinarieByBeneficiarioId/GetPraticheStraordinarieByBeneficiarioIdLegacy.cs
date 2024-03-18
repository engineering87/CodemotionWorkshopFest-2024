using AutoMapper;
using MediatR;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.ViewModels;
using PraticaStraordinaria.Application.Interfaces.Repositories;
using PraticaStraordinaria.Application.Wrappers;

namespace PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.GetPraticaStraordinariaById
{
    public class GetPraticheStraordinarieByBeneficiarioIdLegacy : IRequest<Response<IEnumerable<PraticaStraordinariaViewModel>>>
    {
        public Guid Id { get; set; }
    }

    public class GetPraticheStraordinarieByBeneficiarioIdLegacyHandler(IPraticaLegacyRepositoryAsync praticheLegacyRepository, IMapper mapper)
        : IRequestHandler<GetPraticheStraordinarieByBeneficiarioIdLegacy, Response<IEnumerable<PraticaStraordinariaViewModel>>>
    {
        private readonly IPraticaLegacyRepositoryAsync _praticheLegacyRepository = praticheLegacyRepository;
        private readonly IMapper _mapper = mapper;
    
        public async Task<Response<IEnumerable<PraticaStraordinariaViewModel>>> Handle(GetPraticheStraordinarieByBeneficiarioIdLegacy query, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Straordinarie viene iniettato nel costruttore primario
            // Viene recuperata la pratica in base all'IdBeneficiario specificato
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione delle Pratiche

            var pratiche = await _praticheLegacyRepository.GetByIdBeneficiarioAsync(query.Id);
            var praticheViewModel = _mapper.Map<IEnumerable<PraticaStraordinariaViewModel>>(pratiche);
            return new Response<IEnumerable<PraticaStraordinariaViewModel>>(praticheViewModel);
        }
    }
}