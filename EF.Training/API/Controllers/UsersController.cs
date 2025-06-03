using EF.Training.Application.DTO;
using EF.Training.Application.Interfaces;
using EF.Training.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EF.Training.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly IUserService _userService;

  public UsersController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  public async Task<List<User>> GetAllUsers()
  {
    return await _userService.GetAllUsersAsync();
  }

  [HttpPost]
  public async Task<User> CreateUser(CreateUserDto request)
  {
    User user = await _userService.CreateUserAsync(request);

    return user;
  }
}