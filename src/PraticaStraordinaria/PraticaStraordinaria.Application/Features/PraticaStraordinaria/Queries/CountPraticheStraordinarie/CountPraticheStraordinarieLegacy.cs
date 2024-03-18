using MediatR;
using PraticaStraordinaria.Application.Interfaces.Repositories;
using PraticaStraordinaria.Application.Wrappers;

namespace PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.CountPraticheStraordinarie
{
    public class CountPraticheStraordinarieLegacy : IRequest<Response<int>>
    {
    }

    public class CountPraticheStraordinarieLegacyHandler(IPraticaStraordinariaRepositoryAsync praticheStraordinarieRepository)
        : IRequestHandler<CountPraticheStraordinarieLegacy, Response<int>>
    {
        private readonly IPraticaStraordinariaRepositoryAsync _praticheStraordinarieRepository = praticheStraordinarieRepository;

        public async Task<Response<int>> Handle(CountPraticheStraordinarieLegacy query, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Straordinarie viene iniettato nel costruttore primario
            // Viene effettuato il conteggio delle Pratiche Straordinarie

            var count = await _praticheStraordinarieRepository.CountAsync();

            return new Response<int>(count);
        }
    }
}
