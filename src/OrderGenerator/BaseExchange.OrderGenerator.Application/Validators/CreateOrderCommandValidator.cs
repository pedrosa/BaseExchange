using BaseExchange.OrderGenerator.Application.Commands;
using FluentValidation;

namespace BaseExchange.OrderGenerator.Application.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Symbol)
                .NotEmpty()
                .Must(symbol => new[] { "PETR4", "VALE3", "VIIA4" }.Contains(symbol))
                .WithMessage("Symbol must be one of: PETR4, VALE3, VIIA4");

            RuleFor(x => x.Side)
                .NotEmpty()
                .Must(side => new[] { "Buy", "Sell" }.Contains(side))
                .WithMessage("Side must be either Buy or Sell");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .LessThan(100000)
                .WithMessage("Quantity must be between 1 and 99,999");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .LessThan(1000)
                .Must(price => price % 0.01m == 0)
                .WithMessage("Price must be between 0.01 and 999.99 and be a multiple of 0.01");
        }
    }
}