using App.Queries;
using FluentValidation;
using mi_feature.Api.Database.Repository;

namespace mi_feature.Api.Queries
{
    public class ObtenerPolizaIndividualValidator : AbstractValidator<ObtenerPolizaQuery>
    {
        private readonly IPolizaRepository _polizaRepository;



        public ObtenerPolizaIndividualValidator(IPolizaRepository polizaRepository)
        {
            RuleFor(x => x.Poliza)
               .Must(SerUnaPolizaDeSaludLocal).WithMessage("La póliza debe ser Salud Local.");

            RuleFor(x => x.Poliza)
                .MustAsync(async (poliza, cancellation) =>
                    !await polizaRepository.EsPolizaColectiva(poliza))
                .WithMessage("El número de póliza no puede ser Colectiva.");

            RuleFor(x => x.Poliza)
                .MustAsync(async (poliza, cancellation) =>
                    await polizaRepository.EsPolizaIndividual(poliza))
                .WithMessage("El número de póliza debe ser Individual.");

        }

        private bool SerUnaPolizaDeSaludLocal(string poliza)
        {
            return poliza.StartsWith("3095");
        }
    }
}
