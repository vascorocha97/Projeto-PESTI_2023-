using System.Data;

namespace PESTI_MinimalAPIs.Data;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
}