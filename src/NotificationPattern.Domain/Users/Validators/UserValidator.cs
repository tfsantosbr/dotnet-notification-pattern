using FluentValidation;
using NotificationPattern.Domain.Entities;

namespace NotificationPattern.Domain.Users.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.CompleteName).NotEmpty();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
        }
    }
}
