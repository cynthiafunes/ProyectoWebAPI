// CONTIENE LAS CLASES REPOSITORY PARA LOS MÉTODOS CRUD Y LISTADO
//CRUD (Get, Add, Update, Delete)
//Listado GetAll

//Conexión Correcta a la Capa Repository:
//se implementa la interfaz IRepository<T> para realizar operaciones CRUD en las entidades Cliente y Factura respectivamente.

using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }

    public class ClienteRepository : IRepository<Cliente>
{
    private readonly DatabaseContext _context;

    public ClienteRepository(DatabaseContext context)
    {
        _context = context;
    }

    // Obtener los datos del cliente solo si el estado está activo:
   public Cliente Get(int id)
{
    if (_context == null)
    {
        throw new InvalidOperationException("_context is null.");
    }

    return _context.Clientes.FirstOrDefault(c => c.Id == id && c.Estado == "activo");
}

public IEnumerable<Cliente> GetAll()
{
    if (_context == null)
    {
        throw new InvalidOperationException("_context is null.");
    }

    return _context.Clientes.Where(c => c.Estado == "activo").ToList();
}


    public void Add(Cliente entity)
    {
        _context.Clientes.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Cliente entity)
    {
        _context.Clientes.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }

    public bool DocumentoExists(string documento)
    {
        return _context.Clientes.Any(c => c.Documento == documento);
    }
}

}
