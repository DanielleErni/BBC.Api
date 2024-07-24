using AutoMapper;
using BBC.Api.Dto.CustomerDto;
using BBC.Api.Entities;
using static BBC.Api.Dto.GetOrderDto;


public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Customer to CustomerWithOrdersDto
        CreateMap<CustomerEntity, CustomerWithOrdersDto>()
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));

        CreateMap<CreateCustomerDto, CustomerEntity>();


        // Order to OrderDto
        CreateMap<OrderEntity, OrderDto>()
            .ForMember(dest => dest.Games, opt => opt.MapFrom(src => src.Games));

        // Game to GameDto
        CreateMap<GameEntity, GameDto>();
    }
}