using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sneaker.Models;
using Sneaker.ViewModel;
using Sneaker.Context;

namespace Sneaker.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductSizeController : Controller
    {
        private ModelContext db;

        public ProductSizeController(ModelContext modelContext)
        {
            db = modelContext;
        }

        public IActionResult Index()
        {
            return View(db.ProductSizes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProductSizeViewModel productSizeViewModel = new ProductSizeViewModel
            {
                Products = db.Products.ToList(),
                Sizes = db.Sizes.ToList()
            };
            return View(productSizeViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductSize productSize, ProductSizeViewModel productSizeViewModel)
        {
            productSize.ProductId = productSizeViewModel.SelectProduct;
            productSize.SizeId = productSizeViewModel.SelectSize;

            db.ProductSizes.Add(productSize);
            db.SaveChanges();
            return RedirectToAction("Index");      
        }

        // ДОПИСАТЬ

        //public async Task<IActionResult> Delete(int id)
        //{
        //    Img img = br.Get(id);
        //    return View(img);
        //}


        //[HttpPost]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id != null)
        //    {
        //        br.Delete(id);
        //        br.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return NotFound();
        //}

    }
}