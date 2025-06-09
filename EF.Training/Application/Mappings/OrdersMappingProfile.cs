using AutoMapper;
using EF.Training.Application.DTO;
using EF.Training.Domain.Entities;

namespace EF.Training.Application.Mappings;

public class OrdersMappingProfile : Profile
{
  public OrdersMappingProfile()
  {
    CreateMap<Order, OrderResponseDto>();
    CreateMap<CreateOrderDto, Order>();
    CreateMap<UpdateOrderDto, Order>();
  }
}