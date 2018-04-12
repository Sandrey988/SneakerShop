using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Repositories.Interfaces;
using Sneaker.Models;
using Sneaker.Context;
using Microsoft.EntityFrameworkCore;

namespace Sneaker.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ModelContext db;
        public CategoryRepository(ModelContext model) { db = model; }

        public IEnumerable<Category> GetAll => db.Categories;

        public void Create(Category category)
        {
            db.Categories.Add(category);
        }

        public void Delete(int? id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
                db.Categories.Remove(category);
        }
         
        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public void Edit(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
