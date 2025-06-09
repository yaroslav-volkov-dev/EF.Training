using EF.Training.Application.DTO;

namespace EF.Training.Application.Interfaces;

public interface IUserService
{
  Task<List<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken);
  Task<UserResponseDto> CreateOneAsync(CreateUserDto request, CancellationToken cancellationToken);
}