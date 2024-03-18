using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.CountPraticheOrdinarie;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.GetAllPraticheOrdinarie;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.GetPraticaOrdinariaById;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.ViewModels;
using PraticaOrdinaria.Application.Wrappers;

namespace PraticaOrdinaria.Api.Controllers.v1
{
    /// <summary>
    /// Il Controller v1.0 recupera i dati dal DB legacy: 'PraticheLegacy'
    /// </summary>
    [ApiVersion("1.0")]
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
        public async Task<IActionResult> GetAll([FromQuery] GetAllPraticheOrdinarieQueryLegacy filter)
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo GetAllPraticheOrdinarieQueryLegacy sarà gestito da GetAllPraticheOrdinarieQueryLegacyHandler

            return Ok(await Mediator.Send(filter));
        }

        /// <summary>
        /// Recupero la lista delle Pratiche Ordinarie del BeneficiarioId specificato
        /// </summary>
        /// <param name="beneficiarioId">Id Beneficiario</param>
        /// <returns>Lista delle Pratiche Ordinarie</returns>
        [HttpGet("beneficiario/{id}")]
        [ProducesResponseType(typeof(Response<IEnumerable<PraticaOrdinariaViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByBeneficiarioId(Guid id)
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo GetPraticheOrdinarieByBeneficiarioIdLegacy sarà gestito da GetPraticheOrdinarieByBeneficiarioIdLegacyHandler

            return Ok(await Mediator.Send(new GetPraticheOrdinarieByBeneficiarioIdLegacy()
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
            // L'oggetto di tipo GetPraticaOrdinariaByIdQueryLegacy sarà gestito da GetPraticaOrdinariaByIdQueryLegacyHandler

            return Ok(await Mediator.Send(new GetPraticaOrdinariaByIdQueryLegacy()
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
            // L'oggetto di tipo CountPraticheOrdinarieLegacy sarà gestito da CountPraticheOrdinarieLegacyHandler

            return Ok(await Mediator.Send(new CountPraticheOrdinarieLegacy()));
        }
    }
}
