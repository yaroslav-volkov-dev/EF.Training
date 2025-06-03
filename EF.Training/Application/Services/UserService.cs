using EF.Training.Application.DTO;
using EF.Training.Application.Interfaces;
using EF.Training.Domain.Entities;
using EF.Training.Infrastructure.Interfaces;

namespace EF.Training.Application.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;

  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<List<User>> GetAllUsersAsync()
  {
    return await _userRepository.GetAllUsersAsync();
  }

  public async Task<User> CreateUserAsync(CreateUserDto request)
  {
    return await _userRepository.CreateUserAsync(new User(request.Name, request.Age));
  }
}