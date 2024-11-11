using Microsoft.Extensions.DependencyInjection;
using MovieLookUp.Application.Services;
using MovieLoopUp.Repository.Connection;
using MovieLoopUp.Repository.Repositories;
using MoviesLookUp.Application.Services;

namespace MovieLookUp.Application;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        // DB
        services.AddTransient<IMovieRepository, MovieRepository>();
        services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();

        // Application
        services.AddTransient<IMovieService, MovieService>();

    }
}
