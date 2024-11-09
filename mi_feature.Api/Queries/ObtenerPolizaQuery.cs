using App.DTOs;
using MediatR;
using mi_feature.Api.Configurations;

namespace App.Queries
{
    public class ObtenerPolizaQuery : IRequest<Result<PolizaDto>>
    {
        public string Poliza { get; set; }
    }
}
