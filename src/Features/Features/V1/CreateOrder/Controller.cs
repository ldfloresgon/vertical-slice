using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vertical.Slice.Core;

namespace Vertical.Slice.Features.Features.V1.CreateOrder
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("orders/v{version:apiVersion}")]

    public class Controller : MediatorControllerBase
    {
        public Controller(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(Request request)
        {
            return RequestAsync(request.ToCommand(), id =>
            {
                return StatusCode(StatusCodes.Status201Created, new { id });
            }, HttpContext.RequestAborted);
        }
    }
}
