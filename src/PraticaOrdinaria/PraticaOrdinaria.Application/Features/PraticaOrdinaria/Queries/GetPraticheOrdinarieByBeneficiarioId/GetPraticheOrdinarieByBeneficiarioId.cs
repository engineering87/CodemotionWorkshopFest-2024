using AutoMapper;
using MediatR;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.ViewModels;
using PraticaOrdinaria.Application.Interfaces.Repositories;
using PraticaOrdinaria.Application.Wrappers;

namespace PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.GetPraticaOrdinariaById
{
    public class GetPraticheOrdinarieByBeneficiarioId : IRequest<Response<IEnumerable<PraticaOrdinariaViewModel>>>
    {
        public Guid Id { get; set; }
    }

    public class GetPraticheOrdinarieByBeneficiarioIdHandler(IPraticaOrdinariaRepositoryAsync praticheOrdinarieRepository, IMapper mapper)
        : IRequestHandler<GetPraticheOrdinarieByBeneficiarioId, Response<IEnumerable<PraticaOrdinariaViewModel>>>
    {
        private readonly IPraticaOrdinariaRepositoryAsync _praticheOrdinarieRepository = praticheOrdinarieRepository;
        private readonly IMapper _mapper = mapper;
    
        public async Task<Response<IEnumerable<PraticaOrdinariaViewModel>>> Handle(GetPraticheOrdinarieByBeneficiarioId query, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Ordinarie viene iniettato nel costruttore primario
            // Viene recuperata la pratica in base all'IdBeneficiario specificato
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione delle Pratiche

            var pratiche = await _praticheOrdinarieRepository.GetByIdBeneficiarioAsync(query.Id);
            var praticheViewModel = _mapper.Map<IEnumerable<PraticaOrdinariaViewModel>>(pratiche);
            return new Response<IEnumerable<PraticaOrdinariaViewModel>>(praticheViewModel);
        }
    }
}