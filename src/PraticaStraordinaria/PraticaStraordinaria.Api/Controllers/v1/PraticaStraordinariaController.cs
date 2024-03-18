using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.CountPraticheStraordinarie;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.GetAllPraticheStraordinarie;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.GetPraticaStraordinariaById;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.ViewModels;
using PraticaStraordinaria.Application.Wrappers;

namespace PraticaStraordinaria.Api.Controllers.v1
{
    /// <summary>
    /// Il Controller v1.0 recupera i dati dal DB legacy: 'PraticheLegacy'
    /// </summary>
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
    public class PraticaStraordinariaController : BaseApiController
    {
        /// <summary>
        /// Recupero la lista delle Pratiche Straordinarie, paginando i risultati
        /// </summary>
        /// <param name="filter">Filtro di paginazione</param>
        /// <returns>Lista delle Pratiche Straordinarie</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPraticheStraordinarieQueryLegacy filter)
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo GetAllPraticheStraordinarieQueryLegacy sarà gestito da GetAllPraticheStraordinarieQueryLegacyHandler

            return Ok(await Mediator.Send(filter));
        }

        /// <summary>
        /// Recupero la lista delle Pratiche Straordinarie del BeneficiarioId specificato
        /// </summary>
        /// <param name="beneficiarioId">Id Beneficiario</param>
        /// <returns>Lista delle Pratiche Straordinarie</returns>
        [HttpGet("beneficiario/{id}")]
        [ProducesResponseType(typeof(Response<IEnumerable<PraticaStraordinariaViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByBeneficiarioId(Guid id)
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo GetPraticheStraordinarieByBeneficiarioIdLegacy sarà gestito da GetPraticheStraordinarieByBeneficiarioIdLegacyHandler

            return Ok(await Mediator.Send(new GetPraticheStraordinarieByBeneficiarioIdLegacy()
            {
                Id = id
            }));
        }

        /// <summary>
        /// Recupero la Pratica Straordinaria in base all'Id
        /// </summary>
        /// <param name="id">Id della Pratica Straordinaria</param>
        /// <returns>La Pratica Straordinaria</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<PraticaStraordinariaViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo GetPraticaStraordinariaByIdQueryLegacy sarà gestito da GetPraticaStraordinariaByIdQueryLegacyHandler

            return Ok(await Mediator.Send(new GetPraticaStraordinariaByIdQueryLegacy()
            {
                Id = id
            }));
        }

        /// <summary>
        /// Restituisce il conteggio delle Pratiche Straordinarie
        /// </summary>
        /// <returns>Numero di Pratiche Straordinarie</returns>
        [HttpGet("count")]
        [ProducesResponseType(typeof(Response<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Count()
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo CountPraticheStraordinarieLegacy sarà gestito da CountPraticheStraordinarieLegacyHandler

            return Ok(await Mediator.Send(new CountPraticheStraordinarieLegacy()));
        }
    }
}
