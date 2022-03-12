using KVendasWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KVendasWeb.Controllers
{
    public class DepartamentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departament> list = new List<Departament>();
            list.Add(new Departament { Id = 1, Name = "Eletronicos" });
            list.Add(new Departament { Id = 2, Name = "Fashion" });

            return View(list);
        }
    }
}
