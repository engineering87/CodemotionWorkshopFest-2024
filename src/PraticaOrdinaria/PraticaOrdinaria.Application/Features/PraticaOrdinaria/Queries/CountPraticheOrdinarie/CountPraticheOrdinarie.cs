using MediatR;
using PraticaOrdinaria.Application.Interfaces.Repositories;
using PraticaOrdinaria.Application.Wrappers;

namespace PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.CountPraticheOrdinarie
{
    public class CountPraticheOrdinarie : IRequest<Response<int>>
    {
    }

    public class CountPraticheOrdinarieHandler(IPraticaOrdinariaRepositoryAsync praticheOrdinarieRepository)
        : IRequestHandler<CountPraticheOrdinarie, Response<int>>
    {
        private readonly IPraticaOrdinariaRepositoryAsync _praticheOrdinarieRepository = praticheOrdinarieRepository;

        public async Task<Response<int>> Handle(CountPraticheOrdinarie query, CancellationToken cancellationToken)
        {
            // Il repository specializzato per le Pratiche Ordinarie viene iniettato nel costruttore primario
            // Viene effettuato il conteggio delle Pratiche Ordinarie

            var count = await _praticheOrdinarieRepository.CountAsync();

            return new Response<int>(count);
        }
    }
}
