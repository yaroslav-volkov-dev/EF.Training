using EF.Training.Domain.Entities;

namespace EF.Training.Infrastructure.Interfaces;

public interface IUserRepository
{
  Task<List<User>> GetAllAsync();
  Task AddAsync(User user);
}