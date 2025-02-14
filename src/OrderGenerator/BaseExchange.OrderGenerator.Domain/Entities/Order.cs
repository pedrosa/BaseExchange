using BaseExchange.OrderGenerator.Domain.Common;
using BaseExchange.OrderGenerator.Domain.Enums;
using BaseExchange.OrderGenerator.Domain.ValueObjects;

namespace BaseExchange.OrderGenerator.Domain.Entities
{
    public class Order : Entity
    {
        public Symbol Symbol { get; private set; }
        public Side Side { get; private set; }
        public Quantity Quantity { get; private set; }
        public Money Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatus Status { get; private set; }

        private Order(Symbol symbol, Side side, Quantity quantity, Money price)
        {
            Symbol = symbol;
            Side = side;
            Quantity = quantity;
            Price = price;
            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.New;
        }

        public static Result<Order> Create(Symbol symbol, Side side, Quantity quantity, Money price)
        {
            return Result.Success(new Order(symbol, side, quantity, price));
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }
    }
}