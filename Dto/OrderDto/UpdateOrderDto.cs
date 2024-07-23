namespace BBC.Api.Dto.OrderDto;

public record class UpdateOrderDto
(
    List<int> GameIds,
    int CustomerId
);
