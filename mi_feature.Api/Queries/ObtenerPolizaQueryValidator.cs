using FluentValidation;

namespace App.Queries
{
    public class ObtenerPolizaQueryValidator : AbstractValidator<ObtenerPolizaQuery>
    {
        public ObtenerPolizaQueryValidator()
        {
            const int CINCO = 5; 
            RuleFor(x => x.Poliza)
                .NotEmpty().WithMessage("El número de póliza es obligatorio.")
                .MinimumLength(CINCO-1).WithMessage($"El número de póliza debe contener minimo {CINCO} dígitos")
                .Matches(@"^\d+$").WithMessage("El número de póliza debe ser un número.");
        }
    }
}
