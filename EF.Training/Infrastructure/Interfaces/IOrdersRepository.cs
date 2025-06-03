using EF.Training.Domain.Entities;

namespace EF.Training.Infrastructure.Interfaces;

public interface IOrdersRepository
{
  Task<List<Order>> GetOrdersAsync(int pageNumber, int pageSize);
  Task<Order> CreateOrderAsync(int usedId, string name, string description);
  Task<Order> UpdateOrderAsync(Order updatedOrder);
  Task<bool> DeleteOrderAsync(int id);
}