using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Context;
using Sneaker.Models;
using Sneaker.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sneaker.Services;
using Sneaker.Services.Interfaces;

namespace Sneaker.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        private ModelContext db;
        private DbSet<Brand> dbset;

        public BrandRepository(ModelContext model)
        {
            db = model;
        }

        public IEnumerable<Brand> GetAll =>  db.Brands;


        public void SetStorageContext(IStorageContext storageContext)
        {
            db = storageContext as ModelContext;
            dbset = db.Set<Brand>();

        }

        public void Create(Brand brand)
        {
             db.Brands.Add(brand);
        }

        public void Delete(int? id)
        {
            Brand brand = db.Brands.Find(id);
            if (brand != null)
                db.Brands.Remove(brand);
        }

        public Brand Get(int id)
        {
            return db.Brands.Find(id);
        }

        public void Edit(Brand brand)
        {
            db.Entry(brand).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
