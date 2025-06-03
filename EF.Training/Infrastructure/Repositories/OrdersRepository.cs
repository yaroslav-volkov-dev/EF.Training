using EF.Training.Domain.Entities;
using EF.Training.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF.Training.Infrastructure.Repositories;

public class OrdersRepository : IOrdersRepository
{
  private readonly ApplicationContext _context;

  public OrdersRepository(ApplicationContext context)
  {
    _context = context;
  }

  public async Task<List<Order>> GetOrdersAsync(int pageNumber, int pageSize)
  {
    return await _context.Orders
      .Skip((pageNumber - 1) * pageSize)
      .Take(pageSize)
      .ToListAsync();
  }

  public async Task<Order> CreateOrderAsync(Order order)
  {
    bool isUserExist = await _context.Users.AnyAsync(u => u.Id == order.UserId);

    if (!isUserExist)
    {
      throw new ArgumentException("User does not exist.");
    }

    _context.Orders.Add(order);
    await _context.SaveChangesAsync();

    return order;
  }

  public async Task<bool> DeleteOrderAsync(int id)
  {
    Order? order = await _context.Orders.FindAsync(id);

    if (order is null)
    {
      throw new ArgumentException("Such order does not exist.");
    }

    _context.Orders.Remove(order);
    await _context.SaveChangesAsync();

    return true;
  }

  public async Task<Order> UpdateOrderAsync(Order updatedOrder)
  {
    Order? order = await _context.Orders.FindAsync(updatedOrder.Id);

    if (order is null)
    {
      throw new ArgumentException("Such order does not exist.");
    }

    order.UpdateName(updatedOrder.Name);
    order.UpdateDescription(updatedOrder.Description);
    order.ChangeUser(updatedOrder.UserId);

    await _context.SaveChangesAsync();

    return order;
  }
}