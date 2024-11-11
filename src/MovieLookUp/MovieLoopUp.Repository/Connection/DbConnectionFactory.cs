using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace MovieLoopUp.Repository.Connection;
public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _configuration;

    public DbConnectionFactory(IConfiguration configuration)
    {
          _configuration = configuration;
    }

    public SqlConnection Create()
    {
        return new SqlConnection(_configuration.GetConnectionString("AzureDB.Movies"));
    }
}
