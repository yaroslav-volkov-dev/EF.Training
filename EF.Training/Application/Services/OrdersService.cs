using AutoMapper;
using EF.Training.Application.DTO;
using EF.Training.Application.Interfaces;
using EF.Training.Domain.Entities;

namespace EF.Training.Application.Services;

public class OrdersService : IOrdersService
{
  private readonly IMapper _mapper;
  private readonly IOrdersRepository _ordersRepository;

  public OrdersService(
    IOrdersRepository ordersRepository,
    IMapper mapper
  )
  {
    _ordersRepository = ordersRepository;
    _mapper = mapper;
  }

  public async Task<List<OrderResponseDto>> GetAllAsync(int pageNumber, int pageSize,
    CancellationToken cancellationToken)
  {
    List<Order> orders = await _ordersRepository.GetAllAsync(pageNumber, pageSize, cancellationToken);
    return _mapper.Map<List<OrderResponseDto>>(orders);
  }

  public async Task<OrderResponseDto> CreateOneAsync(CreateOrderDto request, CancellationToken cancellationToken)
  {
    Order? order = _mapper.Map<Order>(request);
    Order createdOrder = await _ordersRepository.CreateOneAsync(order, cancellationToken);

    return _mapper.Map<OrderResponseDto>(createdOrder);
  }

  public Task<Order> UpdateOneAsync(UpdateOrderDto order)
  {
    throw new NotImplementedException();
  }

  public Task<bool> DeleteOneAsync(int id)
  {
    throw new NotImplementedException();
  }
}