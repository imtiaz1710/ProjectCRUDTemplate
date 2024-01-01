using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ProjectCRUDTemplate.Infrustructure.Data.DbContexts;

public class ProjectQueryDbContext(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    private readonly string _connectionString = configuration.GetConnectionString("DbConnection");
    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);
}
