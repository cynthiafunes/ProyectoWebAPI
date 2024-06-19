//CONTIENE UNA CLASE CONEXIÓN

// Conexión Correcta a la Capa Repository:
// se define el contexto de la base de datos utilizando Entity Framework Core 
// y se establece las propiedades DbSet para Clientes y Facturas.

using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
    }
}
