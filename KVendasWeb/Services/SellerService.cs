using KVendasWeb.Data;
using KVendasWeb.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using KVendasWeb.Services.Exceptions;

namespace KVendasWeb.Services
{
    public class SellerService
    {
        private readonly KVendasWebContext _context;

        public SellerService(KVendasWebContext context) 
        {
            _context = context;
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj); 
            _context.SaveChanges();
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList(); 
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Departament).FirstOrDefault(obj => obj.Id == id);
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new KeyNotFoundException("Vendedor não encontrado!");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id); 
            _context.Seller.Remove(obj);
            _context.SaveChanges(); 
        }
    }
}