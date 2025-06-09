using EF.Training.Domain.Entities;

namespace EF.Training.Application.Interfaces;

public interface IUserRepository
{
  Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
  Task<User> CreateOneAsync(User user, CancellationToken cancellationToken);
}