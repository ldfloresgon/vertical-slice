using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vertical.Slice.Core;

namespace Vertical.Slice.Features.Features.V1.GetOrder
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("orders/v{version:apiVersion}")]

    public class Controller : MediatorControllerBase
    {
        public Controller(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(string id)
        {
            return RequestAsync(new Command
            {
                Id = id
            }, id =>
            {
                return StatusCode(StatusCodes.Status201Created, new { id });
            }, HttpContext.RequestAborted);
        }
    }
}
