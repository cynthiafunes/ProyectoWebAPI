using Repository; // Agregar esta línea para importar el espacio de nombres donde está definido Cliente

namespace Service
{
    public class ClienteService
    {
        public bool ValidateCliente(Cliente cliente)
        {
            // Implementa las validaciones requeridas para Cliente según FluentValidation
            // Ejemplo básico:
            if (string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrEmpty(cliente.Apellido) || string.IsNullOrEmpty(cliente.Documento))
                return false;
            if (cliente.Nombre.Length < 3 || cliente.Apellido.Length < 3 || cliente.Documento.Length < 7)
                return false;
            if (!int.TryParse(cliente.Celular, out _) || cliente.Celular.Length != 10)
                return false;
            return true;
        }
    }
}
