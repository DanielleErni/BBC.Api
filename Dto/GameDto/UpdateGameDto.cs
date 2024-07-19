namespace BBC.Api.Dto.GameDto;

public record class UpdateGameDto
(
    string Title,
    string Genre,
    int Quantity,
    double Price
);
