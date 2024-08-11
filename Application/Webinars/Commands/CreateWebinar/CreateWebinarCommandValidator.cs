using FluentValidation;

namespace Application.Webinars.Commands.CreateWebinar;

public sealed class CreateWebinarCommandValidator : AbstractValidator<CreateWebinarCommand>
{
    public CreateWebinarCommandValidator()
    {
        RuleFor(i => i.Name).NotEmpty();
        RuleFor(i => i.ScheduledOn).NotEmpty();
    }
}
