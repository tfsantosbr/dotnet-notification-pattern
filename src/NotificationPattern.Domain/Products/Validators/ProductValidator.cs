using FluentValidation;

namespace NotificationPattern.Domain.Products.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.EAN).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(p => p.Stock).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}