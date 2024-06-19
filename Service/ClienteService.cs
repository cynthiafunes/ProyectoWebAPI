using Repository;
using FluentValidation;

namespace Service
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        private readonly DatabaseContext _context;

        public ClienteValidator(DatabaseContext context)
        {
            _context = context;

            //Nombre y Apellido Obligatorios y mínimo de caracteres 3:
            RuleFor(cliente => cliente.Nombre).NotEmpty().MinimumLength(3);
            RuleFor(cliente => cliente.Apellido).NotEmpty().MinimumLength(3);
            //Documento no debe estar repetido, es obligatorio debe contener un mínimo de 7 caracteres:
            RuleFor(cliente => cliente.Documento).NotEmpty().MinimumLength(7).Must(DocumentoRepetido).WithMessage("El documento ya existe.");
            //Celular como dato numérico de longitud 10:
            RuleFor(cliente => cliente.Celular).NotEmpty().Length(10).Must(cel => int.TryParse(cel, out _)).WithMessage("El celular debe contener solo números.");
            //RuleFor(cliente => cliente.Mail).NotEmpty().EmailAddress();
            RuleFor(cliente => cliente.Mail).NotEmpty().EmailAddress();
        }

        private bool DocumentoRepetido(string documento)
        {
            var existingCliente = _context.Clientes.Any(c => c.Documento == documento);
            return !existingCliente;
        }
    }

    public class ClienteService
    {
        private readonly ClienteValidator _validator;

        public ClienteService(DatabaseContext context)
        {
            _validator = new ClienteValidator(context);
        }

        public bool ValidateCliente(Cliente cliente)
        {
            var result = _validator.Validate(cliente);
            return result.IsValid;
        }
    }
}
