using App.DTOs;
using FluentValidation;
using MediatR;
using mi_feature.Api.Configurations;
using mi_feature.Api.Controllers.Helpers;
using mi_feature.Api.Database.Repository;

namespace App.Queries
{
    public class ObtenerPolizaHandler : IRequestHandler<ObtenerPolizaQuery, ApiResponse<PolizaDto>>
    {
        private readonly IPolizaRepository _repository;
        private readonly IValidator<ObtenerPolizaQuery> _validator;


        public ObtenerPolizaHandler(IPolizaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<PolizaDto>> Handle(ObtenerPolizaQuery request, CancellationToken cancellationToken)
        {
            if(request.Poliza.Equals("30953")) return ApiResponse<PolizaDto>.NotFoundResponse("Número de poliza no encontrada.");
            if (request.Poliza.Equals("30954")) return ApiResponse<PolizaDto>.InternalServerErrorResponse();
            var poliza = await _repository.ObtenerPolizaPorIdAsync(request.Poliza);
       

            return ApiResponse<PolizaDto>.SuccessResponse(poliza);
        }
    }
}
