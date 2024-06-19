using Repository;
using FluentValidation;

namespace Service
{
    public class FacturaValidator : AbstractValidator<Factura>
    {
        public FacturaValidator()
        {
            RuleFor(factura => factura.Nro_factura).Matches(@"^\d{3}-\d{3}-\d{6}$");
            RuleFor(factura => factura.Total).NotEmpty().GreaterThan(0);
            RuleFor(factura => factura.Total_iva5).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(factura => factura.Total_iva10).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(factura => factura.Total_iva).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(factura => factura.Total_letras).NotEmpty().MinimumLength(6);
        }
    }

    public class FacturaService
    {
        private readonly FacturaValidator _validator;

        public FacturaService()
        {
            _validator = new FacturaValidator();
        }

        public bool ValidateFactura(Factura factura)
        {
            var result = _validator.Validate(factura);
            return result.IsValid;
        }
    }
}
