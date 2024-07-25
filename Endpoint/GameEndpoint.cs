using BBC.Api.Data;
using BBC.Api.Entities;
using BBC.Api.Mapping;
using Microsoft.EntityFrameworkCore;
using static BBC.Api.Dto.GameDto;

namespace BBC.Api.Endpoint;

public static class GameEndpoint
{
    public static RouteGroupBuilder MapGameEndpoint(this WebApplication app)
    {
        var GameEP = app.MapGroup("Game");

        // GET ALL
        GameEP.MapGet("/", async (BBCContext dbContext) =>
        {
            var games = await dbContext.Games
                .Select(g => g.ToGameDto())
                .ToListAsync();
            return Results.Ok(games);
        });

        // GET SPECIFIC
        GameEP.MapGet("/{id}", async (int id, BBCContext dbContext) =>
        {
            var gameDets = await dbContext.Games.FindAsync(id);
            if (gameDets == null)
            {
                return Results.NotFound("Game not found");
            }
            return Results.Ok(gameDets.ToGameDto());
        });

        // POST
        GameEP.MapPost("/", async (BBCContext dbContext, CreateGameDto newGame) =>
        {
            var gameData = new GameEntity
            {
                Title = newGame.Title!,
                Genre = newGame.Genre!,
                Quantity = newGame.Quantity,
                Price = newGame.Price
            };

            await dbContext.Games.AddAsync(gameData);
            await dbContext.SaveChangesAsync();
            return Results.Created($"/Game/{gameData.Id}", gameData.ToGameDto());
        });

        // PUT
        GameEP.MapPut("/{id}", async (int id, BBCContext dbContext, UpdateGameDto editedGame) =>
        {
            var gameData = await dbContext.Games.FindAsync(id);

            if (gameData == null)
            {
                return Results.NotFound("Game not found");
            }

            gameData.Title = editedGame.Title!;
            gameData.Genre = editedGame.Genre!;
            gameData.Quantity = editedGame.Quantity;
            gameData.Price = editedGame.Price;

            await dbContext.SaveChangesAsync();
            return Results.Ok(gameData.ToGameDto());
        });

        // DELETE
        GameEP.MapDelete("/{id}", async (int id, BBCContext dbContext) =>
        {
            var gameData = await dbContext.Games.FindAsync(id);
            if (gameData == null)
            {
                return Results.NotFound("Game not found");
            }

            dbContext.Games.Remove(gameData);
            await dbContext.SaveChangesAsync();
            return Results.Ok("Data has been deleted successfully");
        });

        return GameEP;
    }
}