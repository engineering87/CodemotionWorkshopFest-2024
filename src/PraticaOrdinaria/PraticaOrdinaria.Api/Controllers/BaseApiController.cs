using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PraticaOrdinaria.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        /// <summary>
        /// Il mediator pattern è un design pattern utilizzato in informatica nella programmazione orientata agli oggetti che incapsula le modalità con cui oggetti diversi interagiscono fra loro.
        /// Si tratta di un pattern comportamentale, ossia operante nel contesto delle interazioni tra oggetti, che ha l'intento di disaccoppiare entità del sistema che devono comunicare fra loro. Il pattern infatti fa in modo che queste entità non si referenzino reciprocamente, agendo da "mediatore" fra le parti.
        /// Il beneficio principale è il permettere di modificare agilmente le politiche di interazione, poiché le entità coinvolte devono fare riferimento al loro interno solamente al mediatore.
        /// </summary>
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
