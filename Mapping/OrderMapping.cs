using BBC.Api.Dto;
using BBC.Api.Entities;

namespace BBC.Api.Mapping;

public static class OrderMapping
{
    public static OrderEntity ToEntity(this CreateOrderDto order){
        return new OrderEntity(){
                GameId = order.GameId,
                //GameDetails = GameData,
                CustomerId = order.CustomerId,
                //CustomerDetails = await DbContext.Customers.FindAsync(newOrder.CustomerId),
                //TotalPrice = TotalValue

            };
    }
    
    // public static OrderEntity ToUpdateEntity(this UpdateOrderDto order, int id){
    //     return new OrderEntity(){
    //             Id = id,
    //             GameId = order.GameId,
    //             //GameDetails = GameData.Id,
    //             CustomerId = order.CustomerId,
    //             //CustomerDetails = order.CustomerId,
    //             //TotalPrice = TotalValue

    //         };
    // }
    public static OrderSummaryDto ToOrderSumDto(this OrderEntity order){
        return new(
            order.Id,
            order.GameId,
            order.CustomerId,
            order.TotalPrice
        );
    }
    public static OrderDetailsDto ToOrderDetailsDto(this OrderEntity order){
        return new(
            order.Id,
            order.GameDetails!,
            order.CustomerDetails!,
            order.TotalPrice
        );
    }
}
