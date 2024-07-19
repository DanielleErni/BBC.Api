using AutoMapper;
using BBC.Api.Data;
using BBC.Api.Dto.GameDto;
using BBC.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BBC.Api.Endpoint;

public static class GameEndpoint
{
    public static RouteGroupBuilder MapGameEndpoint(this WebApplication app){
        var GameEP = app.MapGroup("Game");

        //GET ALL
        GameEP.MapGet("/", (BBCContext dbContext)=>{
            return dbContext.Games;
        });

        //GET SPECIFIC
        GameEP.MapGet("/{id}", async(int id, BBCContext dbContext)=>{
            var customerDets = await dbContext.Games.FindAsync(id);
            return Results.Ok(customerDets);
        });

        //POST
        GameEP.MapPost("/", async(BBCContext dbContext, CreateGameDto newGame,
        IMapper mapper)=>{
            var gameData = mapper.Map<GameEntity>(newGame);

            await dbContext.Games.AddAsync(gameData!);
            await dbContext.SaveChangesAsync();
            return Results.Created($"/Customer/{gameData!.Id}", gameData);
        });

        //PUT
        GameEP.MapPut("/{id}", async(int id, BBCContext dbContext, UpdateGameDto editedGame,
        IMapper mapper)=>{

            var GameData = await dbContext.Games.FindAsync(id);

            if(GameData == null){
                return Results.NotFound();
            }

            mapper.Map(editedGame, GameData);

            await dbContext.SaveChangesAsync();
            return Results.Created($"/Customer/{GameData!.Id}", GameData);
        });

        //DELETE
        GameEP.MapDelete("/{id}", async(int id, BBCContext dbContext)=>{
            await dbContext.Games.Where(el => el.Id == id).ExecuteDeleteAsync(); //where is basically find
                                     
            return Results.Ok("Data has been deleted success");
        });

        return GameEP;
    }
}
