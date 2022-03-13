using System;
using System.Collections.Generic;
using System.Linq; 

namespace KVendasWeb.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departament() { }

        public Departament(int id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void AddSeller(Seller s)
        {
            Sellers.Add(s);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(s => s.TotalSales(initial, final));
        }
    }
}