using EF.Training.Domain.Entities;

namespace EF.Training.Application.Interfaces;

public interface IOrdersRepository
{
  Task<List<Order>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
  Task<Order> CreateOneAsync(Order order, CancellationToken cancellationToken);
  Task<Order> UpdateOneAsync(Order updatedOrder, CancellationToken cancellationToken);
  Task<bool> DeleteOneAsync(int id, CancellationToken cancellationToken);
}