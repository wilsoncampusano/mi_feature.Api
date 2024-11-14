using App.DTOs;
using MediatR;
using mi_feature.Api.Configurations;
using mi_feature.Api.Controllers.Helpers;

namespace App.Queries
{
    public class ObtenerPolizaQuery : IRequest<ApiResponse<PolizaDto>>
    {
        public string Poliza { get; set; }
    }
}
