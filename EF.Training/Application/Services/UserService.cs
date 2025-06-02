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
    return await _userRepository.GetAllAsync();
  }

  public async Task<User> CreateUserAsync(CreateUserDto request)
  {
    User user = new(request.Name, request.Age);
    await _userRepository.AddAsync(user);
    return user;
  }
}