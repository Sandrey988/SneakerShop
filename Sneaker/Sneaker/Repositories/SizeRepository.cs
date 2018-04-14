using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;
using Sneaker.Context;
using Microsoft.EntityFrameworkCore;
using Sneaker.Repositories.Interfaces;

namespace Sneaker.Repositories
{
    public class SizeRepository : IRepository<Size>
    {
        private readonly ModelContext db;
        public SizeRepository(ModelContext model)
        {
            db = model;
        }

        public IEnumerable<Size> GetAll => db.Sizes;

        public void Create(Size size)
        {
            db.Sizes.Add(size);
        }

        public void Delete(int? id)
        {
            Size size = db.Sizes.Find(id);
            if (size != null)
                db.Sizes.Remove(size);
        }

        public Size Get(int id)
        {
            return db.Sizes.Find(id);
        }

        public void Edit(Size size)
        {
            db.Entry(size).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
