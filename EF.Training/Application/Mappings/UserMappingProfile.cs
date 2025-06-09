using AutoMapper;
using EF.Training.Application.DTO;
using EF.Training.Domain.Entities;

namespace EF.Training.Application.Mappings;

public class UserMappingProfile : Profile
{
  public UserMappingProfile()
  {
    CreateMap<User, UserResponseDto>();
    CreateMap<CreateUserDto, User>();
  }
}