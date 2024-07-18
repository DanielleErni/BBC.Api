using BBC.Api.Entities;

namespace BBC.Api.Dto;

public record class OrderDetailsDto
(
    int Id,
    GameEntity GameDetails,
    CustomerEntity CustomerDetails,
    double TotalPrice
);
