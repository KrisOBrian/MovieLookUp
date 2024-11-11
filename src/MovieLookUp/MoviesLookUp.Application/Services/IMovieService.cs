using MovieLookUp.Application.Models;

namespace MovieLookUp.Application.Services;
public interface IMovieService
{
    Task<IEnumerable<Movies>?> GetMovies(string? title, string? genre);
}
