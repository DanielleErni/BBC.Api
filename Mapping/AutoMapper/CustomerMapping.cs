using AutoMapper;
using BBC.Api.Dto.CustomerDto;
using BBC.Api.Entities;

namespace BBC.Api.Mapping.AutoMapper;

public class CreateCustomerMapping : Profile
{
    public CreateCustomerMapping()
    {
        CreateMap<CreateCustomerDto, CustomerEntity>();
        CreateMap<CustomerEntity, CreateCustomerDto>();
        CreateMap<UpdateCustomerDto, CustomerEntity>();
    }
}
