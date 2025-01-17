﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace BBC.Api.Entities;

public class OrderEntity
{
    public int Id {get; set;}
    //public int GameId {get; set;}
    //public  GameEntity? GameDetails { get; set; }

    [ForeignKey("CustomerId")]
    public int CustomerId {get; set;}

    public CustomerEntity? CustomerDetails { get; set; }
    public double TotalPrice {get; set;}
    
    public ICollection<GameEntity> Games { get; set; } = new List<GameEntity>();
}
