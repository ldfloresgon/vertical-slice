namespace Vertical.Slice.Features.Features.V1.CreateOrder;
public static class Mappers
{
    public static Command ToCommand(this Request request)
    {
        return new Command
        {
            Id = request.Id
        };
    }
}
