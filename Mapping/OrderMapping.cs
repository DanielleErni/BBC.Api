
using BBC.Api.Entities;
using static BBC.Api.Dto.OrderDto;

namespace BBC.Api.Mapping
{
    public static class OrderMapping
    {
        //Create
        public static OrderEntity ToCreateOrderEntity(this CreateOrderDto dto, CustomerEntity customer, List<GameEntity> games)
        {
            return new OrderEntity
            {
                CustomerId = customer.Id,
                CustomerDetails = customer,
                Games = games,
                TotalPrice = games.Sum(g => g.Price)
            };
        }

        public static OrderDetailsDto ToOrderDetailsDto(this OrderEntity order)
        {
            return new OrderDetailsDto
            {
                Id = order.Id,
                Games = order.Games.Select(g => g.ToGameDto()).ToList(),
                TotalPrice = order.TotalPrice
            };
        }

        public static OrderSummaryDto ToOrderSumDto(this OrderEntity order)
        {
            return new OrderSummaryDto
            {
                Id = order.Id,
                GameIds = order.Games.Select(g => g.Id).ToList(),
                CustomerId = order.CustomerId,
                TotalPrice = order.TotalPrice
            };
        }
    }
}