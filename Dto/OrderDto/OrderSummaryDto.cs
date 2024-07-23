namespace BBC.Api.Dto.OrderDto;

public record class OrderSummaryDto
(
    int Id,
    List<int> GameId,
    int CustomerId,
    double TotalPrice
);