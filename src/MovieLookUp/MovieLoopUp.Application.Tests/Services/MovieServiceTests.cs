using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using MovieLookUp.Application.Models;
using MovieLookUp.Application.Services;
using MovieLoopUp.Repository.Models;
using MovieLoopUp.Repository.Repositories;
using MoviesLookUp.Application.Services;

namespace MovieLoopUp.Application.Tests.Services;

[TestFixture]
public sealed class MovieServiceTests
{
    private Mock<IMapper> _mapperMock;
    private Mock<IMovieRepository> _movieRepository;
    private Fixture _fixture;
    private IMovieService _sut;


    [SetUp]
    public void Setup()
    {
        _mapperMock = new Mock<IMapper>();
        _movieRepository = new Mock<IMovieRepository>();
        _fixture = new Fixture();
        _sut = new MovieService(_movieRepository.Object, _mapperMock.Object);
    }

    [Test]
    public async Task GetMovies_WhenNoMoviesFound_ReturnsNull()
    {
        _movieRepository.Setup(x => x.GetMovies("title", "genre")).ReturnsAsync(() => null);

        var result = await _sut.GetMovies("title", "genre");

        result.Should().BeNull();
    }

    [Test]
    public async Task GetMovies_WhenMoviesFound_ReturnsExpected()
    {

        var moviesDto = new List<MovieDto>() 
        { 
            new MovieDto 
            { 
                Title = "Title",
                Genre = "Genre"
            }, 
            new MovieDto 
            {
                Title = "Title",
                Genre = "Genre"
            } 
        };

        var movies = new List<Movies>()
        { 
            new Movies
            {
                Title = "Title",
                Genre = "Genre"
            },
            new Movies
            {
                Title = "Title",
                Genre = "Genre"
            }
        };
         
        _movieRepository.Setup(x => x.GetMovies("title", "genre")).ReturnsAsync(moviesDto);

        _mapperMock.Setup(x => x.Map<IEnumerable<Movies>>(moviesDto)).Returns(movies);
        
        var results = await _sut.GetMovies("title", "genre");

        results.Should().NotBeNull();

    }

    [Test]
    public async Task GetMovies_WhenCalled_CallsMovieRespitoryOnce()
    {
        _movieRepository.Setup(x => x.GetMovies("title", "genre"));

        await _sut.GetMovies("title", "genre");

        _movieRepository.Verify(x => x.GetMovies("title", "genre"), Times.Once);


    }
}
