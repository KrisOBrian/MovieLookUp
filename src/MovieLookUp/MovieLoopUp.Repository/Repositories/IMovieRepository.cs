using MovieLoopUp.Repository.Models;

namespace MovieLoopUp.Repository.Repositories;
public interface IMovieRepository
{
    Task<IEnumerable<MovieDto>?> GetMovies(string? title, string? genre);
}