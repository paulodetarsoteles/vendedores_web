using Microsoft.AspNetCore.Mvc;

namespace KVendasWeb.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}