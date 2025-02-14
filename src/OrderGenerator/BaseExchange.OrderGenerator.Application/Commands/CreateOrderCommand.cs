using BaseExchange.OrderGenerator.Domain.Common;
using MediatR;

namespace BaseExchange.OrderGenerator.Application.Commands
{
    public class CreateOrderCommand : IRequest<Result<Guid>>
    {
        public string? Symbol { get; set; }
        public string? Side { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}