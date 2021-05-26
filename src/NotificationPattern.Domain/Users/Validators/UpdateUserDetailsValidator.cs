using FluentValidation;
using NotificationPattern.Domain.Commands;

namespace NotificationPattern.Domain.Users.Validators
{
    public class UpdateUserDetailsValidator : AbstractValidator<UpdateUserDetails>
    {
        public UpdateUserDetailsValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().Length(2, 150);
            RuleFor(p => p.LastName).NotEmpty().Length(2, 150);
        }
    }
}
