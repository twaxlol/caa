using FluentValidation;
using ProductOrder.Application.Commands;

public class ProductValidator : AbstractValidator<CreateProductCommand>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).Length(4, 20);
        RuleFor(x => x.Description).NotEmpty().Length(4, 20);
        RuleFor(x => x.Price).NotEmpty();
        RuleFor(x => x.CategoryId).NotEmpty();
    }
}