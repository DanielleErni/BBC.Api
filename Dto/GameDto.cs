namespace BBC.Api.Dto;

public class GameDto
{
    public class GameDetailsDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
    public class CreateGameDto
    {
        public string? Title {get; set;}
        public string? Genre {get; set;}
        public int Quantity {get; set;}
        public double Price {get; set;}
    }
    public class UpdateGameDto
    {
        public  string? Title {get; set;}
        public  string? Genre {get; set;}
        public  int Quantity {get; set;}
        public  double Price {get; set;}
    }

}

