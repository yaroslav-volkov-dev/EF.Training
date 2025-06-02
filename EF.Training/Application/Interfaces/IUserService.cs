using EF.Training.Application.DTO;
using EF.Training.Domain.Entities;

namespace EF.Training.Application.Interfaces;

public interface IUserService
{
  Task<List<User>> GetAllUsersAsync();
  Task<User> CreateUserAsync(CreateUserDto request);
}