using EF.Training.Application.Interfaces;
using EF.Training.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.Training.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
  private readonly IApplicationContext _context;

  public UserRepository(IApplicationContext context)
  {
    _context = context;
  }

  public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
  {
    return await _context.Users.ToListAsync(cancellationToken);
  }

  public async Task<User> CreateOneAsync(User user, CancellationToken cancellationToken)
  {
    await _context.Users.AddAsync(user, cancellationToken);
    await _context.SaveChangesAsync(cancellationToken);

    return user;
  }
}