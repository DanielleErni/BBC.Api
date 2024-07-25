using static BBC.Api.Dto.OrderDto;

namespace BBC.Api.Dto
{
    public class CustomerDto
    {
        public class CustomerDetailsDto
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public int ContactNumber { get; set; }

        }
        //eto assignment mo kay sir
        public class CustomerWithOrdersDto
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public int ContactNumber { get; set; }
            public List<OrderDetailsDto> Orders { get; set; } = new List<OrderDetailsDto>();
        }
        public class CreateCustomerDto
        {
            public string? Name { get; set; }
            public int ContactNumber { get; set; }

        }
        public class UpdateCustomerDto
        {
            public string? Name { get; set; }
            public int ContactNumber { get; set; }
        }
    }
}