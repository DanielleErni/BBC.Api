namespace BBC.Api.Dto.GameDto;

public record class CreateGameDto
(
    string Title,
    string Genre,
    int Quantity,
    double Price
);
