using EF.Training.Domain.Entities;
using EF.Training.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF.Training.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
  private readonly ApplicationContext _context;

  public UserRepository(ApplicationContext context)
  {
    _context = context;
  }

  public async Task<List<User>> GetAllAsync()
  {
    return await _context.Users.ToListAsync();
  }

  public async Task AddAsync(User user)
  {
    await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();
  }
}