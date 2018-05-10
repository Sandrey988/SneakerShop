using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sneaker.Models;
using Sneaker.Context;
using Sneaker.ViewModel;

namespace Sneaker.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private ModelContext db;

        public CardController(ModelContext modelContext)
        {
            db = modelContext;
        }

        public IActionResult Index()
        {
            return View(db.Orders);
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            List<ProductView> productView = new List<ProductView>();
            if (id != null)
            {
                Product product = db.Products.FirstOrDefault(x => x.ProductId == id);
                Img img = db.Imgs.First(x => x.Id == id);
                productView.Add(new ProductView
                {
                    Id = product.ProductId,
                    Name = product.ProductName,
                    Price = product.Price,
                    UrlImage = img.ImgUrl
                });
                if (productView != null)
                    return View(productView);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(ProductView productView, Order order)
        {
            order.UrlImage = productView.UrlImage;
            order.ProductId = productView.Id;
            order.Name = productView.Name;
            order.Price = productView.Price;

            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productView);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Order order = db.Orders.Find(id);
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Order order =  db.Orders.FirstOrDefault(p => p.OrderId == id);
                if (order != null)
                {
                    db.Orders.Remove(order);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}