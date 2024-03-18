using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Beneficiari.Application.Wrappers;
using Beneficiari.Application.Features.Beneficiari.ViewModels;
using Beneficiari.Application.Features.Beneficiari.Queries.GetAllBeneficiari;
using Beneficiari.Application.Features.Beneficiari.Queries.GetBeneficiarioById;

namespace Beneficiari.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
    public class BeneficiariController : BaseApiController
    {
        /// <summary>
        /// Recupero la lista dei Beneficiari, paginando i risultati
        /// </summary>
        /// <param name="filter">Filtro di paginazione</param>
        /// <returns>Lista dei Beneficiari</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<BeneficiarioViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBeneficiariQuery filter)
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo GetAllBeneficiariQuery sarà gestito da GetAllBeneficiariQueryHandler

            return Ok(await Mediator.Send(filter));
        }

        /// <summary>
        /// Recupero il Beneficiario in base all'Id
        /// </summary>
        /// <param name="id">Id del Beneficiario</param>
        /// <returns>Il Beneficiario</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<BeneficiarioViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            // MediatR indirizza la richiesta all'handler corretto in base al tipo dell'oggetto inviato
            // L'oggetto di tipo GetBeneficiarioByIdQuery sarà gestito da GetBeneficiarioByIdQueryHandler

            return Ok(await Mediator.Send(new GetBeneficiarioByIdQuery()
            {
                Id = id
            }));
        }
    }
}
