using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ApiGateway.Application.Wrappers;
using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Features.PraticaOrdinaria;
using ApiGateway.Application.Features.Pratica;
using ApiGateway.Domain.DTOs;

namespace ApiGateway.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
    public class PraticaController : BaseApiController
    {
        [HttpGet("beneficiario/{id}")]
        [ProducesResponseType(typeof(Response<IEnumerable<PraticaViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByBeneficiarioId(Guid id)
        {
            return Ok(await Mediator.Send(new GetPraticheByBeneficiarioId()
            {
                Id = id
            }));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<PraticaViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetPraticaById()
            {
                Id = id
            }));
        }

        [HttpGet("count")]
        [ProducesResponseType(typeof(Response<ContatoriPratiche>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Count()
        {
            return Ok(await Mediator.Send(new CountPratiche()));
        }
    }
}
