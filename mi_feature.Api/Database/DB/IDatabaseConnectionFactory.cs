using System.Data;

namespace mi_feature.Api.Database.DB
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection CreateConnection(string databaseIdentifier);

    }
}
