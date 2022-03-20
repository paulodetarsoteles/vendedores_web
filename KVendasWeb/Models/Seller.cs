using System;
using System.Collections.Generic;
using System.Linq; 

namespace KVendasWeb.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public int DepartamentID { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthday, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Birthday = birthday;
            BaseSalary = baseSalary;
            Departament = departament ?? throw new ArgumentNullException(nameof(departament));
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr); 
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final)
                .Sum(sr => sr.Amount); 
        }
    }
}