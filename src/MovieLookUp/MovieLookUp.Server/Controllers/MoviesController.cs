using Microsoft.AspNetCore.Mvc;
using MovieLookUp.Application.Services;
using MovieLookUp.Server.Models.Requests;

namespace MovieLookUp.Server.Controllers;
[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly ILogger<MoviesController> _logger;
    private readonly IMovieService _movieService;

    public MoviesController(ILogger<MoviesController> logger, IMovieService movieService)
    {
        _logger = logger;
        _movieService = movieService;
    }

    [HttpGet]
    [Route("movies")]
    public async Task<IActionResult> GetMoviesAsync([FromQuery] MovieSearch search)
    {

        if(string.IsNullOrEmpty(search.Title) || string.IsNullOrEmpty(search.Genre))
        {
            return BadRequest("Please provide a movie title and/or genre to search.");
        }

        var result = await _movieService.GetMovies(search.Title, search.Genre);

        if(result == null)
        {
            return NotFound("No movies found.");
        }

        return Ok(result);
    }
}
