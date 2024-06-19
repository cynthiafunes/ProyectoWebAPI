using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class FacturaRepository : IRepository<Factura>
    {
        private readonly DatabaseContext _context;

        public FacturaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Factura Get(int id)
        {
            return _context.Facturas.Find(id);
        }

        public IEnumerable<Factura> GetAll()
        {
            return _context.Facturas.ToList();
        }

        public void Add(Factura entity)
        {
            _context.Facturas.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Factura entity)
        {
            _context.Facturas.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var factura = _context.Facturas.Find(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
                _context.SaveChanges();
            }
        }
    }
}
