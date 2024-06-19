using Repository;
using FluentValidation;

namespace Service
{
    public class FacturaValidator : AbstractValidator<Factura>
    {
        public FacturaValidator()
        {
            //Nro. Factura de tipo cadena con patrones como 3 primeros caracteres con datos numéricos,
            //4to carácter guión, posiciones del 5 al 7 con datos numéricos, 8va posición con guión, 
            //6 caracteres últimos con datos numéricos.
            RuleFor(factura => factura.Nro_factura).Matches(@"^\d{3}-\d{3}-\d{6}$");

            //Total, Total_iva5, Total_iva10, Total_iva datos de tipo numéricos obligatorios.
            RuleFor(factura => factura.Total)
            .NotEmpty().WithMessage("El campo Total es obligatorio.")
            .Must(value => decimal.TryParse(value.ToString(), out _)).WithMessage("El campo Total debe ser numérico.");

            RuleFor(factura => factura.Total_iva5)
            .NotEmpty().WithMessage("El campo Total_iva5 es obligatorio.")
            .Must(value => decimal.TryParse(value.ToString(), out _)).WithMessage("El campo Total_iva5 debe ser numérico.");

            RuleFor(factura => factura.Total_iva10)
            .NotEmpty().WithMessage("El campo Total_iva10 es obligatorio.")
            .Must(value => decimal.TryParse(value.ToString(), out _)).WithMessage("El campo Total_iva10 debe ser numérico.");

            RuleFor(factura => factura.Total_iva)
            .NotEmpty().WithMessage("El campo Total_iva es obligatorio.")
            .Must(value => decimal.TryParse(value.ToString(), out _)).WithMessage("El campo Total_iva debe ser numérico.");

            //Total en letras obligatorio, al menos 6 caracteres.
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
