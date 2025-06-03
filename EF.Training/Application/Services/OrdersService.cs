using EF.Training.Application.DTO;
using EF.Training.Application.Interfaces;
using EF.Training.Domain.Entities;
using EF.Training.Infrastructure.Interfaces;

namespace EF.Training.Application.Services;

public class OrdersService : IOrdersService
{
  private readonly IOrdersRepository _ordersRepository;

  public OrdersService(IOrdersRepository ordersRepository)
  {
    _ordersRepository = ordersRepository;
  }

  public async Task<List<Order>> GetAllOrdersAsync(int pageNumber, int pageSize)
  {
    return await _ordersRepository.GetOrdersAsync(pageNumber, pageSize);
  }

  public async Task<Order> CreateOrderAsync(CreateOrderDto request)
  {
    return await _ordersRepository.CreateOrderAsync(new Order(request.UserId, request.Name, request.Description));
  }

  public Task<Order> UpdateOrderAsync(UpdateOrderDto odrer)
  {
    throw new NotImplementedException();
  }

  public Task<bool> DeleteOrderAsync(int id)
  {
    throw new NotImplementedException();
  }
}