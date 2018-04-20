using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.ViewModel;
using Sneaker.Models;
using Sneaker.Context;
using Sneaker.Repositories.Interfaces;

namespace Sneaker.Repositories
{
    public class ProductViewRepository : IProductViewRepository
    {

        private readonly ModelContext db;
        public ProductViewRepository(ModelContext model)
        {
            db = model;
        }

        public Brand Get( int id)
        {
            return db.Brands.Find(id);
        }

        public void GetProductElement(int id, ProductView productView)
        {
            Brand brand = db.Brands.Find(id);
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
            
        }

        public void GetProductElement(int id)
        {
            throw new NotImplementedException();
        }
    }
}
