using BBC.Api.Data;
using BBC.Api.Dto.OrderDto;
using BBC.Api.Entities;
using BBC.Api.Mapping;
using Microsoft.EntityFrameworkCore;

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
                    .Select(order => order.ToOrderSumDto())
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
                var CustomerData = await dbContext.Customers.FindAsync(newOrder.CustomerId);
                if (CustomerData == null)
                {
                    return Results.NotFound("Customer not found");
                }

                var GamesData = new List<GameEntity>();

                foreach (var game in newOrder.GameIds)
                {
                    var gameData = await dbContext.Games.FirstOrDefaultAsync(g => g.Id == game);

                    if (gameData == null) return Results.NotFound();

                    GamesData.Add(gameData);
                }
                    
                if (GamesData.Count != newOrder.GameIds.Count)
                {
                    return Results.NotFound("One or more games not found");
                }

                var orderEntity = newOrder.ToEntity(CustomerData, GamesData);

                await dbContext.Orders.AddAsync(orderEntity);
                await dbContext.SaveChangesAsync();

                return Results.Created($"origin/orders/{orderEntity.Id}", orderEntity.ToOrderDetailsDto());
            });

            OrderEP.MapPut("/{id}", async (int id, BBCContext dbContext, UpdateOrderDto editedOrder) =>
            {
                var existingOrder = await dbContext.Orders
                    .Include(o => o.Games)
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (existingOrder == null)
                {
                    return Results.NotFound("Order not found");
                }

                var CustomerData = await dbContext.Customers.FindAsync(editedOrder.CustomerId);
                if (CustomerData == null)
                {
                    return Results.NotFound("Customer not found");
                }

                var GamesData = await dbContext.Games
                    .Where(g => editedOrder.GameIds.Contains(g.Id))
                    .ToListAsync();

                if (GamesData.Count != editedOrder.GameIds.Count)
                {
                    return Results.NotFound("One or more games not found");
                }

                existingOrder.CustomerId = editedOrder.CustomerId;
                existingOrder.CustomerDetails = CustomerData;
                existingOrder.TotalPrice = GamesData.Sum(g => g.Price * g.Quantity);

                existingOrder.Games.Clear();
                foreach (var game in GamesData)
                {
                    existingOrder.Games.Add(game);
                }

                await dbContext.SaveChangesAsync();

                var DetailedEditedOrderInfo = existingOrder.ToOrderDetailsDto();

                return Results.Ok(DetailedEditedOrderInfo);
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