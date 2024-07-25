using BBC.Api.Data;
using BBC.Api.Entities;
using BBC.Api.Mapping;
using Microsoft.EntityFrameworkCore;
using static BBC.Api.Dto.OrderDto;

namespace BBC.Api.Endpoint
{
    public static class OrdersEndpoint
    {
        public static RouteGroupBuilder MapOrderEndpoint(this WebApplication app)
        {
            var OrderEP = app.MapGroup("Order");

            OrderEP.MapGet("/", async (BBCContext DbContext) =>
            {
                return await DbContext.Orders
                    .Include(o => o.Games)
                    .Select(o => o.ToOrderSumDto())
                    .AsNoTracking()
                    .ToListAsync();
            });

            OrderEP.MapGet("/{id}", async (int id, BBCContext DbContext) =>
            {
                OrderEntity? order = await DbContext.Orders
                    .Include(order => order.Games)
                    .Include(order => order.CustomerDetails)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(order => order.Id == id);

                if (order == null)
                {
                    return Results.NotFound();
                }

                if (order.CustomerDetails == null)
                {
                    return Results.Problem("Customer details are missing.");
                }

                if (order.Games == null)
                {
                    return Results.Problem("Games are missing.");
                }

                return Results.Ok(order.ToOrderDetailsDto());
            });

            OrderEP.MapPost("/", async (CreateOrderDto newOrder, BBCContext dbContext) =>
            {
                //find games check if those exist in db
                var games = await dbContext.Games
                                            //loops on every element LINQ GOAT
                                            .Where(g=> newOrder.GameIds!.Contains(g.Id))
                                            .ToListAsync();
                
                if(games == null){
                    return Results.NotFound("No Games Found");
                }

                //check if customer exist in db
                var customer = await dbContext.Customers
                                  .FirstOrDefaultAsync(c => c.Id == newOrder.CustomerId);
                if(customer == null){
                    return Results.NotFound("No Customer Found");
                }

                var Order = newOrder.ToCreateOrderEntity(customer, games);

                dbContext.Orders.Add(Order);
                await dbContext.SaveChangesAsync();

                


                return Results.Created($"origin/orders/{Order.Id}", Order.ToOrderDetailsDto());
            });

            OrderEP.MapPut("/{id}", async (int id, BBCContext dbContext, UpdateOrderDto editedOrder) =>
            {
                // Check if the order exists
                var existingOrder = await dbContext.Orders
                    .Include(o => o.Games)
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (existingOrder == null)
                {
                    return Results.NotFound("Order not found");
                }

                // Check if the customer exists
                var customerData = await dbContext.Customers.FindAsync(editedOrder.CustomerId);
                if (customerData == null)
                {
                    return Results.NotFound("Customer not found");
                }

                // Check if the games exist
                var gamesData = await dbContext.Games
                    .Where(g => editedOrder.GameIds!.Contains(g.Id))
                    .ToListAsync();

                // Ensure all specified games exist
                if (gamesData.Count != editedOrder.GameIds!.Count)
                {
                    return Results.NotFound("One or more games not found");
                }

                // Update the order entity with new data
                existingOrder.CustomerDetails = customerData;
                existingOrder.Games = gamesData;
                existingOrder.TotalPrice = gamesData.Sum(g => g.Price * g.Quantity);

                // Save changes to the database
                await dbContext.SaveChangesAsync();

                return Results.Ok(existingOrder.ToOrderDetailsDto());
            });

            OrderEP.MapDelete("/{id}", async (int id, BBCContext dbContext) =>
            {
                var existingOrder = await dbContext.Orders.FindAsync(id);
                if (existingOrder == null)
                {
                    return Results.NotFound("Order not found");
                }

                dbContext.Orders.Remove(existingOrder);
                await dbContext.SaveChangesAsync();

                return Results.Ok("Data has been deleted successfully");
            });

            return OrderEP;
        }
    }
}