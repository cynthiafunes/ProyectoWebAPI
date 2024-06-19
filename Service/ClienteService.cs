using Repository;
using FluentValidation;

namespace Service
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Nombre).NotEmpty().MinimumLength(3);
            RuleFor(cliente => cliente.Apellido).NotEmpty().MinimumLength(3);
            RuleFor(cliente => cliente.Documento).NotEmpty().MinimumLength(7).Must(DocumentoRepetido).WithMessage("El documento ya existe.");
            RuleFor(cliente => cliente.Celular).NotEmpty().Length(10).Must(cel => int.TryParse(cel, out _)).WithMessage("El celular debe contener solo números.");
            RuleFor(cliente => cliente.Mail).NotEmpty().EmailAddress();
        }

        private bool DocumentoRepetido(string documento)
        {
            // Lógica para comprobar si el documento está repetido
            return false;
        }
    }

    public class ClienteService
    {
        private readonly ClienteValidator _validator;

        public ClienteService()
        {
            _validator = new ClienteValidator();
        }

        public bool ValidateCliente(Cliente cliente)
        {
            var result = _validator.Validate(cliente);
            return result.IsValid;
        }
    }
}
