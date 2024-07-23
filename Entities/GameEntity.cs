using System.Text.Json.Serialization;

namespace BBC.Api.Entities;

public class GameEntity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    [JsonIgnore]
    public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

}
