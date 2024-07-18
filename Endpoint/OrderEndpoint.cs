
using BBC.Api.Data;
using BBC.Api.Dto;
using BBC.Api.Entities;
using BBC.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BBC.Api.Endpoint;

public static class BooksEndpoint
{

    public static RouteGroupBuilder MapOrderEndpoint(this WebApplication app){

        var OrderEP = app.MapGroup("Order");

        OrderEP.MapGet("/", async(BBCContext DbContext)=>{
            return await DbContext.Orders  //change this into Order
                            .Select(order => order.ToOrderSumDto())
                            .AsNoTracking()
                            .ToListAsync();
                        
        });
        
        OrderEP.MapGet("/{id}", async(int id, BBCContext DbContext) =>{
            //var existingOrder = await DbContext.Orders.FindAsync(id); //change this into Order
            
            OrderEntity? order = await DbContext.Orders
                                                .Include(order => order.GameDetails)
                                                .Include(order => order.CustomerDetails)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(order => order.Id == id);
                        

            
            return order is null ? Results.NotFound() : Results.Ok(order.ToOrderDetailsDto());
        });

        OrderEP.MapPost("/", async(CreateOrderDto newOrder, BBCContext dbContext)=>{

            var GameData = await dbContext.Games.FindAsync(newOrder.GameId);

            if(GameData== null){
                return Results.NotFound();
            }

            double TotalValue = GameData.Price * GameData.Quantity;

            // OrderEntity order = new(){
            //     GameId = newOrder.GameId,
            //     GameDetails = GameData,
            //     CustomerId = newOrder.CustomerId,
            //     CustomerDetails = await DbContext.Customers.FindAsync(newOrder.CustomerId),
            //     TotalPrice = TotalValue

            // };

            OrderEntity order = newOrder.ToEntity();
            order.GameDetails = GameData;
            order.CustomerDetails = await dbContext.Customers.FindAsync(newOrder.CustomerId);
            order.TotalPrice = TotalValue;


            //OrderDetailsDto 

            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            return Results.Created($"origin/orders/{order.Id}", order.ToOrderDetailsDto());
        });

        OrderEP.MapPut("/{id}", async(int id, BBCContext dbContext, UpdateOrderDto editedOrder)=>{
            var existingOrder = await dbContext.Orders.FindAsync(id);


            if(existingOrder == null){
                return Results.NotFound();
            }

            var GameData = await dbContext.Games.FindAsync(editedOrder.GameId);

            double TotalValue = GameData!.Price * GameData!.Quantity;

            existingOrder.GameId = editedOrder.GameId;
            existingOrder.GameDetails = GameData;
            existingOrder.CustomerId = editedOrder.CustomerId;
            existingOrder.CustomerDetails = await dbContext.Customers.FindAsync(editedOrder.CustomerId);
            await dbContext.SaveChangesAsync();
            

            var DetailedEditedOrderInfo = existingOrder.ToOrderDetailsDto();

            return Results.Ok(DetailedEditedOrderInfo);
        });


        OrderEP.MapDelete("/{id}", async(int id, BBCContext dbContext)=>{

            await dbContext.Orders.Where(order => order.Id == id) //where is basically find
                                  .ExecuteDeleteAsync();
            return Results.Ok();
        });



        return OrderEP;
    }

}
