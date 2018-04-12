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

namespace Sneaker.Controllers.AdminControllers
{
    public class ProductViewController : Controller
    {
        private ModelContext db;

        public ProductViewController(ModelContext context)
        {
            db = context;
        }

        public IActionResult Index(int? id)
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
                Product product = db.Products.FirstOrDefault(x=> x.ProductId == id);
                Models.Sneaker sneaker = db.Sneakers.FirstOrDefault(x=> x.SneakerId == product.SneakerId);
                Img img = db.Imgs.FirstOrDefault(x=> x.SneakerId == product.SneakerId);
                Brand brand = db.Brands.FirstOrDefault(x => x.Id == sneaker.BrandId);
                Material material = db.Materials.FirstOrDefault(x => x.Id == sneaker.MaterialId);
                Category category = db.Categories.FirstOrDefault(x => x.Id == sneaker.CategoryId);
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
                    MaterialName = material.MaterialName

                });
                if (productView != null)
                    return View(productView);
            }
            return NotFound();
        }

    }
}




