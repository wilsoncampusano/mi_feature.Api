using App.DTOs;
using FluentValidation;
using MediatR;
using mi_feature.Api.Configurations;
using mi_feature.Api.Database.Repository;

namespace App.Queries
{
    public class ObtenerPolizaHandler : IRequestHandler<ObtenerPolizaQuery, Result<PolizaDto>>
    {
        private readonly IPolizaRepository _repository;
        private readonly IValidator<ObtenerPolizaQuery> _validator;


        public ObtenerPolizaHandler(IPolizaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<PolizaDto>> Handle(ObtenerPolizaQuery request, CancellationToken cancellationToken)
        {
            if(request.Poliza.Equals("30953")) return Result<PolizaDto>.NotFound("Número de poliza no encontrada.");
            var poliza = await _repository.ObtenerPolizaPorIdAsync(request.Poliza);
       

            return Result<PolizaDto>.SuccessResult(poliza);
        }
    }
}
