using MediatR;

namespace Vertical.Slice.Features.Features.V1.CreateOrder;
public class Command : IRequest<string>
{
    public string Id { get; set; }
}
