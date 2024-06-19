using Repository; // Agregar esta línea para importar el espacio de nombres donde está definido Factura

namespace Service
{
    public class FacturaService
    {
        public bool ValidateFactura(Factura factura)
        {
            // Implementa las validaciones requeridas para Factura según FluentValidation
            // Ejemplo básico:
            // Aquí se implementan las validaciones específicas para Nro_factura, Total, etc.
            return true;
        }
    }
}
