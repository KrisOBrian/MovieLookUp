using Dapper;
using MovieLoopUp.Repository.Connection;
using MovieLoopUp.Repository.Models;

namespace MovieLoopUp.Repository.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public MovieRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<MovieDto>?> GetMovies(string? title, string? genre)
    {
        await using var connection = _dbConnectionFactory.Create();

        var sql = @"SELECT * 
                    FROM MovieInfo 
                    WHERE (Title LIKE CONCAT('%', @Title, '%') OR @Title IS NULL) 
                    AND (Genre LIKE CONCAT('%', @Genre, '%') OR @Genre IS NULL)";

        var parameters = new {Title = title, Genre = genre};


        var result = await connection.QueryAsync<MovieDto>(sql, parameters);

        if (result.Count() > 0)
        {
            return result;
        }

        return null;

    }
}
