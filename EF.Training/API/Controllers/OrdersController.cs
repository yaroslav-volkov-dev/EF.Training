using EF.Training.Application.DTO;
using EF.Training.Application.Interfaces;
using EF.Training.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EF.Training.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class OrdersController
{
  private readonly IOrdersService _ordersService;

  public OrdersController(IOrdersService ordersService)
  {
    _ordersService = ordersService;
  }

  [HttpGet]
  public async Task<List<Order>> GetOrders()
  {
    return await _ordersService.GetAllOrdersAsync(1, 10);
  }

  [HttpPost]
  public async Task<Order> CreateOrder(CreateOrderDto request)
  {
    return await _ordersService.CreateOrderAsync(request);
  }
}