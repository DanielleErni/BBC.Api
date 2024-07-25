using BBC.Api.Entities;
using static BBC.Api.Dto.GameDto;

namespace BBC.Api.Mapping;

public static class GameMapper
{
    public static GameDetailsDto ToGameDto(this GameEntity game)
    {
        return new GameDetailsDto
        {
            Id = game.Id,
            Title = game.Title,
            Genre = game.Genre,
            Quantity = game.Quantity,
            Price = game.Price
        };
    }
}
