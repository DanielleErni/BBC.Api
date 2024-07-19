using AutoMapper;
using BBC.Api.Dto.GameDto;
using BBC.Api.Entities;

namespace BBC.Api.Mapping.AutoMapper;

public class GameMapping : Profile
{
    public GameMapping(){
        CreateMap<GameEntity, CreateGameDto>();
        CreateMap<CreateGameDto, GameEntity>();
        CreateMap<UpdateGameDto, GameEntity>();
    }
}
