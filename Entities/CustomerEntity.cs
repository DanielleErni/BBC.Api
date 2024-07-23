using System.Text.Json.Serialization;

namespace BBC.Api.Entities;

public class CustomerEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int ContanctNumber { get; set; }

[JsonIgnore]
    public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
}
