using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ApiGateway.Application.Wrappers;
using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Features.Beneficiario;

namespace ApiGateway.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
    public class BeneficiariController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<BeneficiarioViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBeneficiari filter)
        {
            return Ok(await Mediator.Send(filter));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<BeneficiarioViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetBeneficiarioById()
            {
                Id = id
            }));
        }
    }
}
