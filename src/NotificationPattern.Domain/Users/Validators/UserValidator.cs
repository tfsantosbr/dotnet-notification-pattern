using FluentValidation;
using NotificationPattern.Domain.Entities;

namespace NotificationPattern.Domain.Users.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().Length(2, 150);
            RuleFor(p => p.LastName).NotEmpty().Length(2, 150);
            RuleFor(p => p.Email).NotEmpty().Length(2, 150).EmailAddress();
            RuleFor(p => p.Password)
                .NotEmpty()
                .Length(8, 20)
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
        }
    }
}
