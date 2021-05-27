using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Domain.Core.ValueObjects.Validators
{
    public class PasswordValidator : AbstractValidator<Password>
    {
        public PasswordValidator()
        {
            RuleFor(p => p.Value)
                .NotEmpty()
                .Length(2, 30)
                .Matches(@"[A-Z]+").WithMessage("'Password' must contain at least one uppercase letter.")
                .Matches(@"[0-9]+").WithMessage("'Password  must contain at least one number.");
            ;
        }
    }
}
