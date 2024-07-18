namespace BBC.Api.Dto;

public record class OrderSummaryDto
(
    int Id,
    int GameId,
    int CustomerId,
    double TotalPrice
);