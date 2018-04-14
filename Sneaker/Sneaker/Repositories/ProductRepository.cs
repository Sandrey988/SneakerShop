using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;
using Sneaker.ViewModel;
using Sneaker.Repositories.Interfaces;
using Sneaker.Context;
using Microsoft.EntityFrameworkCore;

namespace Sneaker.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModelContext db;
        public ProductRepository(ModelContext model)
        {
            db = model;
        }

        public IEnumerable<Product> GetAll => db.Products;

        public void Create(Product product)
        {
            db.Products.Add(product);
        }

        public void Delete(int? id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
                db.Products.Remove(product);
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public void Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public ProductSneaker GetItemDb()
        {
            ProductSneaker productSneaker = new ProductSneaker
            {
                Sneakers = db.Sneakers.ToList()
            };

            return productSneaker;
        }
    }
}
