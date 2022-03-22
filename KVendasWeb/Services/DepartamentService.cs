using KVendasWeb.Data;
using KVendasWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace KVendasWeb.Services
{
    public class DepartamentService
    {
        private readonly KVendasWebContext _context;
        public DepartamentService(KVendasWebContext context)
        {
            _context = context;
        }
        public async Task<List<Departament>> FindAllAsync()
        {
            return await _context.Departament.OrderBy(x => x.Name).ToListAsync();
        }
    }
}