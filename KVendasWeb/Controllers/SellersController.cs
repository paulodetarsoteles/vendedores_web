using System;
using System.Diagnostics; 
using System.Threading.Tasks;
using System.Collections.Generic;
using KVendasWeb.Models;
using KVendasWeb.Models.ViewModels;
using KVendasWeb.Services;
using KVendasWeb.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace KVendasWeb.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerServices;
        private readonly DepartamentService _departamentService;

        public SellersController(SellerService sellerService, DepartamentService departamentService)
        {
            _sellerServices = sellerService;
            _departamentService = departamentService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sellerServices.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departaments = await _departamentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departaments = departaments };
                return View(viewModel);
            }
            await _sellerServices.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }
            var obj = await _sellerServices.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }
            else
            {
                return View(obj);
            }
        }

        public async Task<IActionResult> Edit(int? id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.FindAllAsync(); 
                var viewModel = new SellerFormViewModel { Seller = seller , Departaments = departaments};
                return View(viewModel);
            }
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }
            var obj = await _sellerServices.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }
            else
            {
                List<Departament> departaments = await _departamentService.FindAllAsync();
                SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departaments = departaments };
                return View(viewModel);
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde!" });
            }
            else
            {
                try
                {
                    await _sellerServices.UpdateAsync(seller);
                    return RedirectToAction(nameof(Index));
                }
                catch (ApplicationException e)
                {
                    return RedirectToAction(nameof(Error), new { message = e.Message });
                }
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" }); 
            }
            var obj = await _sellerServices.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }
            else
            {
                return View(obj);
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
            await _sellerServices.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            }; 
            return View(viewModel);
        }
    }
}