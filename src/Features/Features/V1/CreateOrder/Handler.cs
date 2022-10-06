using MediatR;

namespace Vertical.Slice.Features.Features.V1.CreateOrder;
public class Handler : IRequestHandler<Command, string>
{
    public Task<string> Handle(Command request, CancellationToken cancellationToken)
    {
        //do some logic
        return Task.FromResult(request.Id);
    }
}
