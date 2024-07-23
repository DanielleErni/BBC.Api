namespace BBC.Api.Dto.OrderDto;

public record class CreateOrderDto
(
    List<int> GameIds,
    int CustomerId
);
