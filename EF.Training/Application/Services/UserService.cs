using AutoMapper;
using EF.Training.Application.DTO;
using EF.Training.Application.Interfaces;
using EF.Training.Domain.Entities;

namespace EF.Training.Application.Services;

public class UserService : IUserService
{
  private readonly IMapper _mapper;
  private readonly IUserRepository _userRepository;

  public UserService(
    IUserRepository userRepository,
    IMapper mapper
  )
  {
    _userRepository = userRepository;
    _mapper = mapper;
  }

  public async Task<List<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken)
  {
    List<User> users = await _userRepository.GetAllAsync(cancellationToken);
    return _mapper.Map<List<UserResponseDto>>(users);
  }

  public async Task<UserResponseDto> CreateOneAsync(CreateUserDto request, CancellationToken cancellationToken)
  {
    User user = _mapper.Map<User>(request);
    User createdUser = await _userRepository.CreateOneAsync(user, cancellationToken);

    return _mapper.Map<UserResponseDto>(createdUser);
  }
}