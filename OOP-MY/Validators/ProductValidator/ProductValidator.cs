using FluentValidation;
using OOP_MY.Entities;

namespace OOP_MY.Validators.ProductValidator
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Product name cannot be empty.");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(p => p.Stock).GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative.");
        }
    }
}
