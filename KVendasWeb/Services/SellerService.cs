using KVendasWeb.Data;
using KVendasWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace KVendasWeb.Services
{
    public class SellerService
    {
        private readonly KVendasWebContext _context;
        public SellerService(KVendasWebContext context) 
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList(); 
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj); 
            _context.SaveChanges();
        }
    }
}