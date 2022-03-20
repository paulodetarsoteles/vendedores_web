using Microsoft.AspNetCore.Mvc;
using KVendasWeb.Services;
using KVendasWeb.Models;
using KVendasWeb.Models.ViewModels; 

namespace KVendasWeb.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerServices; 
        private readonly DepartamentService _departamentService;

        public SellersController (SellerService sellerService, DepartamentService departamentService)
        {
            _sellerServices = sellerService;
            _departamentService = departamentService;
        }
        public IActionResult Index()
        {
            var list = _sellerServices.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departaments = _departamentService.FindAll();
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerServices.FindById(id.Value); 
            if (obj == null)
            {
                return NotFound(); 
            }
            else
            {
                return View(obj);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerServices.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return View(obj);
            }
        }
    }
}