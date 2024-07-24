using System.Text.Json.Serialization;

namespace BBC.Api.Entities;

public class CustomerEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int ContactNumber { get; set; }

    public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
}
