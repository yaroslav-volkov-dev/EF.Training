using EF.Training.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.Training.Application.Interfaces;

public interface IApplicationContext
{
  DbSet<User> Users { get; }
  DbSet<Company> Companies { get; }
  DbSet<Order> Orders { get; }
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}