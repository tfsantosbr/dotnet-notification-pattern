using FluentValidation;
using NotificationPattern.Domain.Products.Commands;

namespace NotificationPattern.Domain.Products.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.EAN).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(p => p.Stock).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}