using BBC.Api.Entities;
using static BBC.Api.Dto.CustomerDto;
using static BBC.Api.Dto.OrderDto;

namespace BBC.Api.Mapping;

public static class CustomerManualMapping
{

    public static CustomerDetailsDto ToCustomerDetailsDto(this CustomerEntity customer)
    {
        return new CustomerDetailsDto
        {
            Id = customer.Id,
            Name = customer.Name,
            ContactNumber = customer.ContactNumber
        };
    }

    //<return type> <class name> ()
    public static CustomerWithOrdersDto ToCustomerWithOrdersDto(this CustomerEntity customer)
    {
        return new CustomerWithOrdersDto
        {
            //map simple props
            Id = customer.Id,
            Name = customer.Name,
            ContactNumber = customer.ContactNumber,
            //customer.Orders access the collection.
            //then the LinQ makes each element turn to a DTO
            //then return as a list
            Orders = customer.Orders.Select(o => o.ToOrderDetailsDto()).ToList()
            
        };
    }

}
