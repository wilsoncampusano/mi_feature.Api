using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace mi_feature.Api.Database.DB
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IDictionary<string, string> _connectionStrings;
        public DatabaseConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;

            _connectionStrings = new Dictionary<string, string>
        {
            { "sw", _configuration.GetConnectionString("ConnectionStrings:sw") },
            { "if", _configuration.GetConnectionString("ConnectionStrings:ip") }
        };
        }

        public IDbConnection CreateConnection(string databaseIdentifier)
        {
            if (!_connectionStrings.ContainsKey(databaseIdentifier))
                throw new ArgumentException($"No se encontró la cadena de conexión para el identificador: {databaseIdentifier}");

            var connectionString = _connectionStrings[databaseIdentifier];

            var connection = new OracleConnection(connectionString);
            connection.Open();

            return connection;
        }
    }
}
