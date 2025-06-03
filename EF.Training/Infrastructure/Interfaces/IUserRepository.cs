using EF.Training.Domain.Entities;

namespace EF.Training.Infrastructure.Interfaces;

public interface IUserRepository
{
  Task<List<User>> GetAllUsersAsync();
  Task<User> CreateUserAsync(User user);
}