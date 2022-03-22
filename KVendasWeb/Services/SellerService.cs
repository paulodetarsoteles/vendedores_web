using KVendasWeb.Data;
using KVendasWeb.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using KVendasWeb.Services.Exceptions;
using System.Threading.Tasks;

namespace KVendasWeb.Services
{
    public class SellerService
    {
        private readonly KVendasWebContext _context;

        public SellerService(KVendasWebContext context) 
        {
            _context = context;
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj); 
            await _context.SaveChangesAsync();
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync(); 
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Departament).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task UpdateAsync(Seller obj)
        {
            if (! await _context.Seller.AnyAsync(x => x.Id == obj.Id))
            {
                throw new KeyNotFoundException("Vendedor não encontrado!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id); 
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync(); 
        }
    }
}