using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Context;
using Sneaker.Models;
using Sneaker.Repositories.Interfaces;
using Sneaker.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Sneaker.Repositories
{
    public class SneakerRepository : ISneakerRepository<Models.Sneaker>
    {
        private readonly ModelContext db;
        public SneakerRepository(ModelContext model)
        {
            db = model;
        }

        public IEnumerable<Models.Sneaker> GetAll => db.Sneakers;

        public void Create(Models.Sneaker sneaker)
        {
            db.Sneakers.Add(sneaker);
        }

        public void Delete(int? id)
        {
            Models.Sneaker sneaker = db.Sneakers.Find(id);
            if (sneaker != null)
                db.Sneakers.Remove(sneaker);
        }

        public Models.Sneaker Get(int id)
        {
            return db.Sneakers.Find(id);
        }

        public void Edit(Models.Sneaker sneaker)
        {
            db.Entry(sneaker).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public SneakerAll GetItemDb()
        {
            SneakerAll sneakerAll = new SneakerAll
            {
                Brands = db.Brands.ToList(),
                Categories = db.Categories.ToList(),
                Materials = db.Materials.ToList()
            };

            return sneakerAll;
        }
    }
}
