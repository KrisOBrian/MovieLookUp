using AutoMapper;
using MovieLookUp.Application.Models;
using MovieLookUp.Application.Services;
using MovieLoopUp.Repository.Repositories;

namespace MoviesLookUp.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _Mapper;

    public MovieService(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _Mapper = mapper;
    }

    public async Task<IEnumerable<Movies>?> GetMovies(string? title, string? genre)
    {
        try
        {
            var foundMovies = await _movieRepository.GetMovies(title, genre);

            if (foundMovies != null)
            {

                var mappedMovies = _Mapper.Map<IEnumerable<Movies>>(foundMovies);
                return mappedMovies;
            }

            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
