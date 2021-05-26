using FluentValidation;
using NotificationPattern.Domain.Commands;

namespace NotificationPattern.Domain.Users.Validators
{
    public class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPassword>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(p => p.ConfirmPassword).Equal(p => p.Password);
            RuleFor(p => p.Password)
                .NotEmpty()
                .Length(8, 20)
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
        }
    }
}
