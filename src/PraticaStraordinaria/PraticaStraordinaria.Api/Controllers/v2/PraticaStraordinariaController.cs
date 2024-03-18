using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.CountPraticheStraordinarie;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.GetAllPraticheStraordinarie;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.GetPraticaStraordinariaById;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.ViewModels;
using PraticaStraordinaria.Application.Wrappers;

namespace PraticaStraordinaria.Api.Controllers.v2
{
    /// <summary>
    /// Il Controller v2.0 recupera i dati dal nuovo DB: 'PraticheStraordinarie'
    /// </summary>
    [ApiVersion("2.0")]
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
        public async Task<IActionResult> GetAll([FromQuery] GetAllPraticheStraordinarieQuery filter)
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo GetAllPraticheStraordinarieQuery sarà gestito da GetAllPraticheStraordinarieQueryHandler

            return Ok(await Mediator.Send(filter));
        }

        /// <summary>
        /// Recupero la lista delle Pratiche Straordinarie del BeneficiarioId specificato
        /// </summary>
        /// <param name="id">Id Beneficiario</param>
        /// <returns>Lista delle Pratiche Straordinarie</returns>
        [HttpGet("beneficiario/{id}")]
        [ProducesResponseType(typeof(Response<IEnumerable<PraticaStraordinariaViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByBeneficiarioId(Guid id)
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo GetPraticheStraordinarieByBeneficiarioId sarà gestito da GetPraticheStraordinarieByBeneficiarioIdHandler

            return Ok(await Mediator.Send(new GetPraticheStraordinarieByBeneficiarioId()
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
            // L'oggetto di tipo GetPraticaStraordinariaByIdQuery sarà gestito da GetPraticaStraordinariaByIdQueryHandler

            return Ok(await Mediator.Send(new GetPraticaStraordinariaByIdQuery()
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
            // L'oggetto di tipo CountPraticheStraordinarie sarà gestito da CountPraticheStraordinarieHandler

            return Ok(await Mediator.Send(new CountPraticheStraordinarie()));
        }
    }
}
