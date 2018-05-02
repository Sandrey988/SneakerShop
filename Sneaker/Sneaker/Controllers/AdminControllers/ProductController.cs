using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sneaker.Models;
using Sneaker.ViewModel;
using Microsoft.EntityFrameworkCore;
using Sneaker.Context;
using Sneaker.Repositories.Interfaces;

namespace Sneaker.Controllers.AdminControllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository br;

        public ProductController(IProductRepository productRepository)
        {
            br = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(br.GetAll);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ProductSneaker productSneaker = br.GetItemDb();
            return View(productSneaker);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductSneaker productSneaker, Product product)
        {
            product.ProductName = productSneaker.Name;
            product.SneakerId = productSneaker.SelectSneaker;
            product.Amount = productSneaker.Amount;
            product.Price = productSneaker.Price;

            if (ModelState.IsValid)
            {
                br.Create(product);
                br.Save();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Product product = br.Get(id);
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                br.Delete(id);
                br.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }


    }
}