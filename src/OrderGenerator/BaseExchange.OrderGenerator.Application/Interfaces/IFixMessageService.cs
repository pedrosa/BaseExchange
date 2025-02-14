using BaseExchange.OrderGenerator.Domain.Entities;

namespace BaseExchange.OrderGenerator.Application.Interfaces
{
    public interface IFixMessageService
    {
        Task SendNewOrderSingle(Order order);
    }
}