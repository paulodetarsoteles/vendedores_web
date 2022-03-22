using Microsoft.EntityFrameworkCore;

namespace KVendasWeb.Models
{
    public class KVendasWebContext : DbContext
    {
        public KVendasWebContext (DbContextOptions<KVendasWebContext> options) : base(options) { }
        public DbSet<Departament> Departament { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}