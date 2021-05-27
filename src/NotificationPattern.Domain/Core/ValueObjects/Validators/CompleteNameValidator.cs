using FluentValidation;

namespace NotificationPattern.Domain.Core.ValueObjects.Validators
{
    public class CompleteNameValidator : AbstractValidator<CompleteName>
    {
        public CompleteNameValidator()
        {
            RuleFor(cp => cp.FirstName)
                .NotEmpty()
                .Length(2, 100)
                ;

            RuleFor(cp => cp.LastName)
                .NotEmpty()
                .Length(2, 200);
        }
    }
}
