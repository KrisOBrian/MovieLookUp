namespace MovieLookUp.Server.Models.Responses;

public class MoviesResponse
{
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public int? Year { get; set; }
    public double? Rating { get; set; }
}
