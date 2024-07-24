namespace BBC.Api.Dto;

public class GetOrderDto
{
    public class CustomerWithOrdersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContactNumber { get; set; }
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }

    public record class OrderDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public List<GameDto> Games { get; set; } = new List<GameDto>();
    }

    public class GameDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}