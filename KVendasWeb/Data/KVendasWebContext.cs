using Microsoft.EntityFrameworkCore;
using KVendasWeb.Models; 

namespace KVendasWeb.Data
{
    public class KVendasWebContext : DbContext
    {
        public KVendasWebContext (DbContextOptions<KVendasWebContext> options) : base(options) { }
        public DbSet<Departament> Departament { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}