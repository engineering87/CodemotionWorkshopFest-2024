using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ApiGateway.Application.Wrappers;
using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Features.PraticaOrdinaria;

namespace ApiGateway.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
    public class PraticaOrdinariaController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPraticheOrdinarie filter)
        {
            return Ok(await Mediator.Send(filter));
        }
    }
}
