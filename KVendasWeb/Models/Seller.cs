using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KVendasWeb.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome obrigatorio")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="Digite um nome valido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email obrigatorio")]
        [EmailAddress(ErrorMessage ="Digite um email valido")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
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
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount); 
        }
    }
}