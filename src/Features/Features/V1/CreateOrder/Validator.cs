using FluentValidation;

namespace Vertical.Slice.Features.Features.V1.CreateOrder;
public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(_ => _.Id)
            .NotEmpty()
            .WithMessage("The Id must be inform")
            .NotNull()
            .WithMessage("The Id must be inform")
            .Must(_id => Guid.TryParse(_id, out var guid ))
            .WithMessage("The Id must be a Guid");
    }
}
