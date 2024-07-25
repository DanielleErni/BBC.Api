using static BBC.Api.Dto.GameDto;

namespace BBC.Api.Dto
{
    public class OrderDto
    {
        public class OrderDetailsDto
        {
            public int Id { get; set; }
            public double TotalPrice { get; set; }
            public List<GameDetailsDto> Games { get; set; } = new List<GameDetailsDto>();

        }
        public class OrderSummaryDto
        {
            public int Id { get; set; }
            public List<int>? GameIds { get; set; }
            public int CustomerId { get; set; }
            public double TotalPrice { get; set; }
        }
        public class CreateOrderDto
        {
            public List<int>? GameIds { get; set; }
            public int CustomerId { get; set; }

        }
        public class UpdateOrderDto
        {
            public List<int>? GameIds { get; set; }
            public int CustomerId { get; set; }
        }
    }
}