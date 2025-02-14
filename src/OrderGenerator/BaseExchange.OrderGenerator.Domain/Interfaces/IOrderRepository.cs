
using BaseExchange.OrderGenerator.Domain.Entities;

namespace BaseExchange.OrderGenerator.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order order);
        Task<Order> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task UpdateAsync(Order order);
    }
}