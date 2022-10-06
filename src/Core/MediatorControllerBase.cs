using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Vertical.Slice.Core;
public abstract class MediatorControllerBase : ControllerBase
{
    private readonly IMediator _mediator;

    public MediatorControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected virtual async Task<IActionResult> RequestAsync<TResponse>(IRequest<TResponse> request, Func<TResponse, IActionResult> action, CancellationToken cancellationToken = default)
    {
        action = action ?? throw new ArgumentNullException(nameof(action));

        if (request == null) return BadRequest();

        Func<TResponse, Task<IActionResult>> actionAsync =
            response => Task.FromResult(action(response));

        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            return await actionAsync(response);
        }
        catch (Exception ex)
        {
            return await HandleResponseAsync(ex);
        }
    }

    protected virtual Task<IActionResult> HandleResponseAsync(Exception ex)
        => Task.FromResult<IActionResult>(ex switch
        {
            RequestValidationException rex => BadRequest(rex.Errors),
            _ => StatusCode((int)HttpStatusCode.InternalServerError)
        });
}

