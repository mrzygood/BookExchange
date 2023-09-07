using FluentValidation;

namespace BookExchange.EntryPoint.Configuration;

public sealed class ExampleConfigurationValidation : AbstractValidator<ExampleConfiguration>
{
    public ExampleConfigurationValidation()
    {
        RuleFor(x => x.ExampleField1)
            .NotEmpty()
            .Must(x => x.Length > 5);
    }
}
