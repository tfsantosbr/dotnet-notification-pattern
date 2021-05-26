using FluentValidation;
using NotificationPattern.Domain.Commands;

namespace NotificationPattern.Domain.Users.Validators
{
    public class UpdateUserEmailValidator : AbstractValidator<UpdateUserEmail>
    {
        public UpdateUserEmailValidator()
        {
            RuleFor(p => p.Email).NotEmpty().Length(2, 150).EmailAddress();
        }
    }
}
