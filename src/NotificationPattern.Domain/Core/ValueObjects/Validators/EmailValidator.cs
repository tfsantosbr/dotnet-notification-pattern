using FluentValidation;

namespace NotificationPattern.Domain.Core.ValueObjects.Validators
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(e => e.Address)
                .NotEmpty()
                .MaximumLength(150)
                .EmailAddress();
        }
    }
}
