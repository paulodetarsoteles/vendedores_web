using KVendasWeb.Models;
using KVendasWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace KVendasWeb.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerServices; 

        public SellersController (SellerService sellerService)
        {
            _sellerServices = sellerService;
        }
        public IActionResult Index()
        {
            var list = _sellerServices.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}