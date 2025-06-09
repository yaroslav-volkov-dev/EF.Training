using EF.Training.Application.DTO;
using EF.Training.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EF.Training.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/users")]
[ApiVersion("1.0")]
public class UsersController : ControllerBase
{
  private readonly IUserService _userService;

  public UsersController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  public async Task<List<UserResponseDto>> GetAllUsers(CancellationToken cancellationToken)
  {
    return await _userService.GetAllAsync(cancellationToken);
  }

  [HttpPost]
  public async Task<UserResponseDto> CreateUser(CreateUserDto request, CancellationToken cancellationToken)
  {
    return await _userService.CreateOneAsync(request, cancellationToken);
  }
}