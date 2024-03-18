using AutoMapper;
using MediatR;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.ViewModels;
using PraticaStraordinaria.Application.Interfaces.Repositories;
using PraticaStraordinaria.Application.Wrappers;

namespace PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.GetPraticaStraordinariaById
{
    public class GetPraticheStraordinarieByBeneficiarioId : IRequest<Response<IEnumerable<PraticaStraordinariaViewModel>>>
    {
        public Guid Id { get; set; }
    }

    public class GetPraticheStraordinarieByBeneficiarioIdHandler(IPraticaStraordinariaRepositoryAsync praticheStraordinarieRepository, IMapper mapper)
        : IRequestHandler<GetPraticheStraordinarieByBeneficiarioId, Response<IEnumerable<PraticaStraordinariaViewModel>>>
    {
        private readonly IPraticaStraordinariaRepositoryAsync _praticheStraordinarieRepository = praticheStraordinarieRepository;
        private readonly IMapper _mapper = mapper;
    
        public async Task<Response<IEnumerable<PraticaStraordinariaViewModel>>> Handle(GetPraticheStraordinarieByBeneficiarioId query, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Straordinarie viene iniettato nel costruttore primario
            // Viene recuperata la pratica in base all'IdBeneficiario specificato
            // Il risultato finale viene mappato in un oggetto standardizzato di presentazione delle Pratiche

            var pratiche = await _praticheStraordinarieRepository.GetByIdBeneficiarioAsync(query.Id);
            var praticheViewModel = _mapper.Map<IEnumerable<PraticaStraordinariaViewModel>>(pratiche);
            return new Response<IEnumerable<PraticaStraordinariaViewModel>>(praticheViewModel);
        }
    }
}