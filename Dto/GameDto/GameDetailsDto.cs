namespace BBC.Api.Dto.GameDto;

public record class GameDetailsDto
(
    int Id,
    string Title,
    string Genre,
    int Quantity,
    double Price
);

