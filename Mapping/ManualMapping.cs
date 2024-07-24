using BBC.Api.Entities;
using static BBC.Api.Dto.GetOrderDto;

namespace BBC.Api.Mapping;

public static class ManualMapping
{
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
                Orders = customer.Orders.Select(o => o.ToOrderDto()).ToList()
                
            };
        }
    public static OrderDto ToOrderDto(this OrderEntity order)
    {
        return new OrderDto
        {
            Id = order.Id,
            TotalPrice = order.TotalPrice,
            Games = order.Games.Select(g => g.ToGameDto()).ToList()
        };
    }

    public static GameDto ToGameDto(this GameEntity game)
    {
        return new GameDto
        {
            Id = game.Id,
            Title = game.Title,
            Genre = game.Genre,
            Quantity = game.Quantity,
            Price = game.Price
        };
    }
}
