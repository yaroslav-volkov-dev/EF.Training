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
  public async Task<ActionResult<List<User>>> GetAllUsers()
  {
    List<User> users = await _userService.GetAllUsersAsync();
    return Ok(users);
  }

  [HttpPost]
  public async Task<ActionResult<User>> CreateUser(CreateUserDto request)
  {
    User user = await _userService.CreateUserAsync(request);

    return Ok(user);
  }
}