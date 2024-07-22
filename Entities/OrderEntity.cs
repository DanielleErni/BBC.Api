using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BBC.Api.Entities;

public class OrderEntity
{
    public int Id {get; set;}
    public int GameId {get; set;}
    public  GameEntity? GameDetails { get; set; }
    public int CustomerId {get; set;}

    public CustomerEntity? CustomerDetails { get; set; }
    public double TotalPrice {get; set;}
}
