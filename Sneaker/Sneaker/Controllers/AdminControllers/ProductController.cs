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

namespace Sneaker.Controllers.AdminControllers
{
    public class ProductController : Controller
    {
        private ModelContext db;

        public ProductController(ModelContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        public IActionResult Create()
        {
            ProductSneaker productSneaker = new ProductSneaker
            {
                Sneakers = db.Sneakers.ToList()
            };

            return View(productSneaker);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductSneaker productSneaker, Product product)
        {
            product.ProductName = productSneaker.Name;
            product.SneakerId = productSneaker.SelectSneaker;
            product.Amount = productSneaker.Amount;
            product.Price = productSneaker.Price;
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Product product = new Product { ProductId = id.Value };
                db.Entry(product).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}