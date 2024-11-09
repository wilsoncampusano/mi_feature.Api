using App.DTOs;
using mi_feature.Api.Database.Repository.Base;

namespace mi_feature.Api.Database.Repository
{
    public interface IPolizaRepository:IRepository
    {
        Task<bool> EsPolizaColectiva(string poliza);
        Task<bool> EsPolizaIndividual(string poliza);
        Task<IEnumerable<PolizaDto>> GetAllAsync();
        Task<IEnumerable<PolizaDto>> GetAllFromIpAsync();
        Task<IEnumerable<PolizaDto>> GetAllFromSwAsync();
        Task<PolizaDto> ObtenerPolizaPorIdAsync(string poliza);
    }
}