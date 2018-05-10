using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sneaker.Models;
using Sneaker.ViewModel;
using Sneaker.Context;
using Sneaker.Repositories.Interfaces;

namespace Sneaker.Controllers.AdminControllers
{
    public class ProductViewController : Controller
    {
        private readonly ModelContext db;

        public ProductViewController(ModelContext modelContext)
        {
            db = modelContext;
        }

        public IActionResult Index(int id)
        {
            List<Models.Sneaker> sneakers = new List<Models.Sneaker>();
            sneakers = db.Sneakers.Where(x => x.BrandId == id).ToList();
            List<Product> products = new List<Product>();
            List<ProductView> productsView = new List<ProductView>();

            int sneakerId = 0;
            foreach (var sneaker in sneakers)
            {
                sneakerId = db.Sneakers.Where(x => x.SneakerId == sneaker.SneakerId).FirstOrDefault().SneakerId;
                productsView.Add(new ProductView
                {
                    Id = db.Products.Where(x => x.SneakerId == sneaker.SneakerId).FirstOrDefault().ProductId,
                    BrandName = db.Brands.Where(x => x.Id == sneaker.BrandId).FirstOrDefault().BrandName,
                    Name = db.Sneakers.Where(x => x.SneakerId == sneaker.SneakerId).FirstOrDefault().SneakerName,
                    Price = db.Products.Where(x => x.SneakerId == sneaker.SneakerId).FirstOrDefault().Price,
                    UrlImage = db.Imgs.Where(x => x.SneakerId == sneakerId).FirstOrDefault().ImgUrl
                });
            }
            return View(productsView);
        }

        public IActionResult Details(int? id)
        {
            List<ProductView> productView = new List<ProductView>();
            if (id != null)
            {
                Product product = db.Products.FirstOrDefault(x => x.ProductId == id);
                Models.Sneaker sneaker = db.Sneakers.FirstOrDefault(x => x.SneakerId == product.SneakerId);
                Img img = db.Imgs.FirstOrDefault(x => x.SneakerId == product.SneakerId);
                Brand brand = db.Brands.FirstOrDefault(x => x.Id == sneaker.BrandId);
                Material material = db.Materials.FirstOrDefault(x => x.Id == sneaker.MaterialId);
                Category category = db.Categories.FirstOrDefault(x => x.Id == sneaker.CategoryId);
                List<ProductSize> productSize = db.ProductSizes.Where(x => x.ProductId == product.ProductId).Include(x => x.Size).OrderBy(x => x.Size.Number).ToList();

                productView.Add(new ProductView
                {
                    Id = product.ProductId,
                    Name = sneaker.SneakerName,
                    Amount = product.Amount,
                    UrlImage = img.ImgUrl,
                    Price = product.Price,
                    Description = sneaker.Description,
                    BrandName = brand.BrandName,
                    CategoryName = category.CategoryName,
                    MaterialName = material.MaterialName,
                    Sizes = productSize
                });
                if (productView != null)
                    return View(productView);
            }
            return NotFound();
        }

        public IActionResult Create(int id, Order order, ProductView productView)
        {
            if (ModelState.IsValid)
            {
                order.Name = productView.Name;
                order.Price = productView.Price;

                db.Add(order);
                db.SaveChanges();
            }
            return View("~/Views/Card/Index.cshtml");
        }

        public IActionResult Search(string searchString)
        {
            List<ProductView> productsView = new List<ProductView>();
            try
            {
                IEnumerable<Product> products = db.Products.Where(p => p.ProductName.ToLower().Contains(searchString.ToLower()));

                foreach (var product in products)
                {
                    var sneaker = db.Sneakers.Where(x => x.SneakerId == product.SneakerId).FirstOrDefault();
                    productsView.Add(new ProductView
                    {
                        Id = product.ProductId,
                        BrandName = $"Search \"{searchString}\"",
                        Name = db.Sneakers.Where(x => x.SneakerId == sneaker.SneakerId).FirstOrDefault().SneakerName,
                        Price = db.Products.Where(x => x.SneakerId == sneaker.SneakerId).FirstOrDefault().Price,
                        UrlImage = db.Imgs.Where(x => x.SneakerId == sneaker.SneakerId).FirstOrDefault().ImgUrl
                    });
                }  
            }
            catch (Exception)
            {

            }
            return View("~/Views/ProductView/Index.cshtml", productsView);
        }
    }
}   