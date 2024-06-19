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

        public Cliente Get(int id)
        {
            return _context.Clientes.Find(id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
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
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
