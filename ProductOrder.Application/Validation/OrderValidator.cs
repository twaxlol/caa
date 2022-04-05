using FluentValidation;
using ProductOrder.Application.Commands;
using ProductOrder.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder.Application.Validation
{
    public class OrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public OrderValidator()
        {
            RuleForEach(x => x.Products).SetValidator(new ProductForOrderValidator());
        }
    }
    public class ProductForOrderValidator : AbstractValidator<ProductOrderModel>
    {
        public ProductForOrderValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1);
        }
    }
}
