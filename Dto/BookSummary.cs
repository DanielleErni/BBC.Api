namespace BBC.Api.Dto;

public record class BookSummary
(
    int Id,
    int CustomerId,
    int BookId,
    int GenreId 
);
