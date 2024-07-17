namespace BBC.Api.Dto;

public record class BookSummaryDto
(
    int Id,
    int GameId,
    int CustomerId,
    int Quantity
);