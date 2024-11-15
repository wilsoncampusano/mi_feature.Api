using App.DTOs;
using mi_feature.Api.Database.DB;
using mi_feature.Api.Database.Repository.Base;
using Dapper;
using Microsoft.VisualBasic;


namespace mi_feature.Api.Database.Repository
{
    public class PolizaRepository : IPolizaRepository
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;
        public PolizaRepository(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<PolizaDto> ObtenerPolizaPorIdAsync(string poliza) => new PolizaDto { Poliza = poliza, Nombre = $"Mi Poliza {poliza}" };
        public Task<bool> EsPolizaColectiva(string poliza)
        {
            return Task.FromResult(poliza.StartsWith("30952"));
        }

        public Task<bool> EsPolizaIndividual(string poliza)
        {
            return Task.FromResult(poliza.StartsWith("30951") || poliza.StartsWith("30953") || poliza.StartsWith("30954"));
        }


        public async Task<IEnumerable<PolizaDto>> GetAllAsync()
        {
            return  Enumerable.Concat<PolizaDto>(GetAllFromIpAsync().Result, GetAllFromSwAsync().Result);
        }
        public async Task<IEnumerable<PolizaDto>> GetAllFromIpAsync()
        {
            using (var connection = _connectionFactory.CreateConnection("ip"))
            {
                connection.Open();
                return await connection.QueryAsync<PolizaDto>("SELECT * FROM Poliza");
            }
        }

        public async Task<IEnumerable<PolizaDto>> GetAllFromSwAsync()
        {
            using (var connection = _connectionFactory.CreateConnection("ip"))
            {
                connection.Open();
                return await connection.QueryAsync<PolizaDto>("SELECT * FROM Poliza");
            }
        }

    }
}
