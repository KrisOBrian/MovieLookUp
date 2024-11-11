using AutoFixture;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using MovieLookUp.Application.ApplicationMappings;
using MovieLookUp.Application.Models;
using MovieLoopUp.Repository.Models;

namespace MovieLoopUp.Application.Tests.Mappings;

[TestFixture]
public sealed class ApplicationMappingTests : MappingTests
{
    private Fixture _fixture;
    private IMapper _mapper;

    [OneTimeSetUp]
    public void Setup()
    {
        _fixture = new Fixture();
        _mapper = Setup<ApplicationMappings>();
    }


    [Test]
    public void Mapper_WhenCalled_CorrectlyMapsDtoToMovies()
    {
        var fromModel = _fixture.Create<MovieDto>();

        var result = _mapper.Map<Movies>(fromModel);

        using (new AssertionScope())
        {
            result.Release_Date.Should().Be(fromModel.Release_Date);
            result.Title.Should().Be(fromModel.Title);
            result.Overview.Should().Be(fromModel.Overview);
            result.Popularity.Should().Be(fromModel.Popularity);
            result.Vote_Count.Should().Be(fromModel.Vote_Count);
            result.Vote_Average.Should().Be(fromModel.Vote_Average);
            result.Original_Language.Should().Be(fromModel.Original_Language);
            result.Genre.Should().Be(fromModel.Genre);
            result.Poster_Url.Should().Be(fromModel.Poster_Url);
        }
    }

}
