using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sneaker.Models;
using Sneaker.ViewModel;


namespace Sneaker.Controllers.AdminControllers
{
    public class ProductViewController : Controller
    {
        private ModelContext db;

        public ProductViewController(ModelContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            List<ProductView> products = new List<ProductView>();
            int sneakerId = 0;
            foreach(var product in db.Products.ToList())
            {
                sneakerId = db.Sneakers.Where(x => x.SneakerId == product.SneakerId).FirstOrDefault().SneakerId;
                products.Add(new ProductView
                {
                    Id = product.ProductId,
                    Name = db.Sneakers.Where(x => x.SneakerId == product.SneakerId).FirstOrDefault().SneakerName,
                    Price = product.Price,
                    UrlImage = db.Imgs.Where(x => x.SneakerId == sneakerId).FirstOrDefault().ImgUrl
                });
            }
            return View(products);
        }

        
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                List<ProductView> productView = new List<ProductView>();
                int sneakerId = 0;
                foreach (var product in db.Products.ToList())
                {
                    sneakerId = db.Sneakers.Where(x => x.SneakerId == product.SneakerId).FirstOrDefault(x => x.SneakerId ==id).SneakerId;
                    productView.Add(new ProductView
                    {
                        Id = product.ProductId,
                        Name = db.Sneakers.Where(x => x.SneakerId == product.SneakerId).FirstOrDefault(x=> x.SneakerId ==id).SneakerName,
                        //Price = product.Price,
                        //UrlImage = db.Imgs.Where(x => x.SneakerId == sneakerId).FirstOrDefault().ImgUrl,
                        //Description = db.Sneakers.Where(x => x.SneakerId == sneakerId).FirstOrDefault().Description,
                        //BrandName = db.Sneakers.Where(x => x.BrandId == sneakerId).FirstOrDefault().Brand.BrandName,
                        //MaterialName = db.Sneakers.Where(x => x.MaterialId == sneakerId).FirstOrDefault().Material.MaterialName

                    });
                }

                //Models.Sneaker sneaker = await db.Sneakers.FirstOrDefaultAsync(p => p.SneakerId == id);
                if (productView != null)
                        return View(productView);
            }
            return NotFound();
        }

    }
}