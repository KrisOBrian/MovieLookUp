using System.Data.SqlClient;

namespace MovieLoopUp.Repository.Connection;
public interface IDbConnectionFactory
{
    SqlConnection Create();
}
