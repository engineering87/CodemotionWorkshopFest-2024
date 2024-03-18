using MediatR;
using PraticaStraordinaria.Application.Interfaces.Repositories;
using PraticaStraordinaria.Application.Wrappers;

namespace PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.CountPraticheStraordinarie
{
    public class CountPraticheStraordinarie : IRequest<Response<int>>
    {
    }

    public class CountPraticheStraordinarieHandler(IPraticaStraordinariaRepositoryAsync praticheStraordinarieRepository)
        : IRequestHandler<CountPraticheStraordinarie, Response<int>>
    {
        private readonly IPraticaStraordinariaRepositoryAsync _praticheStraordinarieRepository = praticheStraordinarieRepository;

        public async Task<Response<int>> Handle(CountPraticheStraordinarie query, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Straordinarie viene iniettato nel costruttore primario
            // Viene effettuato il conteggio delle Pratiche Straordinarie

            var count = await _praticheStraordinarieRepository.CountAsync();

            return new Response<int>(count);
        }
    }
}
