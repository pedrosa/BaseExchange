using BaseExchange.OrderGenerator.Application.Commands;
using MediatR;
using BaseExchange.OrderGenerator.Domain.Common;
using BaseExchange.OrderGenerator.Domain.Interfaces;
using BaseExchange.OrderGenerator.Application.Interfaces;
using BaseExchange.OrderGenerator.Domain.Enums;
using BaseExchange.OrderGenerator.Domain.ValueObjects;
using BaseExchange.OrderGenerator.Domain.Entities;

namespace BaseExchange.OrderGenerator.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<Guid>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFixMessageService _fixMessageService;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IFixMessageService fixMessageService)
        {
            _orderRepository = orderRepository;
            _fixMessageService = fixMessageService;
        }

        public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse<Symbol>(request.Symbol, out var symbol))
                return Result.Failure<Guid>($"Invalid symbol: {request.Symbol}");

            if (!Enum.TryParse<Side>(request.Side, out var side))
                return Result.Failure<Guid>($"Invalid side: {request.Side}");

            var quantityResult = Quantity.Create(request.Quantity);
            if (quantityResult.IsFailure)
                return Result.Failure<Guid>(quantityResult.Error);

            var priceResult = Money.Create(request.Price);
            if (priceResult.IsFailure)
                return Result.Failure<Guid>(priceResult.Error);

            var orderResult = Order.Create(
                symbol,
                side,
                quantityResult.Value,
                priceResult.Value);

            if (orderResult.IsFailure)
                return Result.Failure<Guid>(orderResult.Error);

            var savedOrder = await _orderRepository.AddAsync(orderResult.Value);

            await _fixMessageService.SendNewOrderSingle(savedOrder);

            return Result.Success(savedOrder.Id);
        }
    }
}