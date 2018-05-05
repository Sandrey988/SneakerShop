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

        public async Task<IActionResult> Index(int id)
        {
            //int pageSize = 4; // количество элементов на странице
            //IQueryable<Product> source = db.Products.Include(x => x.Sneaker);
            //var count = await source.CountAsync();
            //var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            //  PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
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
                    //Products = items,
                    //PageViewModels = pageViewModel
                });
            }

            return View(productsView);
        }

        public async Task<IActionResult> Details(int? id)
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

        public IActionResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Product> products;
            if (string.IsNullOrEmpty(_searchString))
            {
                products = db.Products.OrderBy(p => p.ProductId);
            }
            else
            {
                products = db.Products.Where(p => p.ProductName.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/ProductView/Index.cshtml", new ProductView {Products = products });
        }



    }
}   