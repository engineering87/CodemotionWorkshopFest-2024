using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.CountPraticheOrdinarie;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.GetAllPraticheOrdinarie;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.GetPraticaOrdinariaById;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.ViewModels;
using PraticaOrdinaria.Application.Wrappers;

namespace PraticaOrdinaria.Api.Controllers.v2
{
    /// <summary>
    /// Il Controller v2.0 recupera i dati dal nuovo DB: 'PraticheOrdinarie'
    /// </summary>
    [ApiVersion("2.0")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
    public class PraticaOrdinariaController : BaseApiController
    {
        /// <summary>
        /// Recupero la lista delle Pratiche Ordinarie, paginando i risultati
        /// </summary>
        /// <param name="filter">Filtro di paginazione</param>
        /// <returns>Lista delle Pratiche Ordinarie</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPraticheOrdinarieQuery filter)
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo GetAllPraticheOrdinarieQuery sarà gestito da GetAllPraticheOrdinarieQueryHandler

            return Ok(await Mediator.Send(filter));
        }

        /// <summary>
        /// Recupero la lista delle Pratiche Ordinarie del BeneficiarioId specificato
        /// </summary>
        /// <param name="id">Id Beneficiario</param>
        /// <returns>Lista delle Pratiche Ordinarie</returns>
        [HttpGet("beneficiario/{id}")]
        [ProducesResponseType(typeof(Response<IEnumerable<PraticaOrdinariaViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByBeneficiarioId(Guid id)
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo GetPraticheOrdinarieByBeneficiarioId sarà gestito da GetPraticheOrdinarieByBeneficiarioIdHandler

            return Ok(await Mediator.Send(new GetPraticheOrdinarieByBeneficiarioId()
            {
                Id = id
            }));
        }

        /// <summary>
        /// Recupero la Pratica Ordinaria in base all'Id
        /// </summary>
        /// <param name="id">Id della Pratica Ordinaria</param>
        /// <returns>La Pratica Ordinaria</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<PraticaOrdinariaViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo GetPraticaOrdinariaByIdQuery sarà gestito da GetPraticaOrdinariaByIdQueryHandler

            return Ok(await Mediator.Send(new GetPraticaOrdinariaByIdQuery()
            { 
                Id = id
            }));
        }

        /// <summary>
        /// Restituisce il conteggio delle Pratiche Ordinarie
        /// </summary>
        /// <returns>Numero di Pratiche Ordinarie</returns>
        [HttpGet("count")]
        [ProducesResponseType(typeof(Response<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Count()
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo CountPraticheOrdinarie sarà gestito da CountPraticheOrdinarieHandler

            return Ok(await Mediator.Send(new CountPraticheOrdinarie()));
        }
    }
}
