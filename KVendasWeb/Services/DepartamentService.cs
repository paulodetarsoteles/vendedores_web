using KVendasWeb.Data;
using KVendasWeb.Models;
using System.Collections.Generic;
using System.Linq; 

namespace KVendasWeb.Services
{
    public class DepartamentService
    {
        private readonly KVendasWebContext _context;
        public DepartamentService(KVendasWebContext context)
        {
            _context = context;
        }
        public List<Departament> FindAll()
        {
            return _context.Departament.OrderBy(x => x.Name).ToList();
        }
    }
}