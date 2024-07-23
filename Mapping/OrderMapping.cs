using BBC.Api.Dto;
using BBC.Api.Dto.OrderDto;
using BBC.Api.Entities;

namespace BBC.Api.Mapping
{
    public static class OrderMapping
    {
        public static OrderEntity ToEntity(this CreateOrderDto dto, CustomerEntity customer, List<GameEntity> games)
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
            return new OrderDetailsDto(
                order.Id,
                order.Games.ToList(),
                order.CustomerDetails!,
                order.TotalPrice
            );
        }

        public static OrderSummaryDto ToOrderSumDto(this OrderEntity order)
        {
            return new OrderSummaryDto(
                order.Id,
                order.Games.Select(g => g.Id).ToList(),
                order.CustomerId,
                order.TotalPrice
            );
        }
    }
}