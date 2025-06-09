using EF.Training.Application.DTO;
using EF.Training.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EF.Training.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/orders")]
[ApiVersion("1.0")]
public class OrdersController
{
  private readonly IOrdersService _ordersService;

  public OrdersController(IOrdersService ordersService)
  {
    _ordersService = ordersService;
  }

  [HttpGet]
  public async Task<List<OrderResponseDto>> GetOrders(
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 20,
    CancellationToken cancellationToken = default)
  {
    return await _ordersService.GetAllAsync(pageNumber, pageSize, cancellationToken);
  }

  [HttpPost]
  public async Task<OrderResponseDto> CreateOrder(CreateOrderDto request, CancellationToken cancellationToken)
  {
    return await _ordersService.CreateOneAsync(request, cancellationToken);
  }
}