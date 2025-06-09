using EF.Training.Application.Interfaces;
using EF.Training.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.Training.Infrastructure.Repositories;

public class OrdersRepository : IOrdersRepository
{
  private readonly IApplicationContext _context;

  public OrdersRepository(IApplicationContext context)
  {
    _context = context;
  }

  public async Task<Order> CreateOneAsync(Order order, CancellationToken cancellationToken)
  {
    bool isUserExist = await _context.Users.AnyAsync(u => u.Id == order.UserId, cancellationToken);

    if (!isUserExist)
    {
      throw new ArgumentException("User does not exist.");
    }

    _context.Orders.Add(order);
    await _context.SaveChangesAsync(cancellationToken);

    return order;
  }

  public async Task<List<Order>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
  {
    return await _context.Orders
      .Include(order => order.User)
      .Skip((pageNumber - 1) * pageSize)
      .Take(pageSize)
      .ToListAsync(cancellationToken);
  }

  public async Task<bool> DeleteOneAsync(int id, CancellationToken cancellationToken)
  {
    Order? order = await _context.Orders.FindAsync(id, cancellationToken);

    if (order is null)
    {
      throw new ArgumentException("Such order does not exist.");
    }

    _context.Orders.Remove(order);
    await _context.SaveChangesAsync(cancellationToken);

    return true;
  }

  public async Task<Order> UpdateOneAsync(Order updatedOrder, CancellationToken cancellationToken)
  {
    Order? order = await _context.Orders.FindAsync(updatedOrder.Id, cancellationToken);

    if (order is null)
    {
      throw new ArgumentException("Such order does not exist.");
    }

    order.UpdateName(updatedOrder.Name);
    order.UpdateDescription(updatedOrder.Description);
    order.ChangeUser(updatedOrder.UserId);

    await _context.SaveChangesAsync(cancellationToken);

    return order;
  }
}