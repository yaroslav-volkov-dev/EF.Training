using EF.Training.Application.DTO;

namespace EF.Training.Application.Interfaces;

public interface IOrdersService
{
  Task<List<OrderResponseDto>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
  Task<OrderResponseDto> CreateOneAsync(CreateOrderDto order, CancellationToken cancellationToken);
}