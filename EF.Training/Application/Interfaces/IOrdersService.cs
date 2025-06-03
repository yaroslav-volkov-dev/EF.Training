using EF.Training.Application.DTO;
using EF.Training.Domain.Entities;

namespace EF.Training.Application.Interfaces;

public interface IOrdersService
{
  Task<List<Order>> GetAllOrdersAsync(int pageNumber, int pageSize);
  Task<Order> CreateOrderAsync(CreateOrderDto order);
  Task<Order> UpdateOrderAsync(UpdateOrderDto odrer);
  Task<bool> DeleteOrderAsync(int id);
}