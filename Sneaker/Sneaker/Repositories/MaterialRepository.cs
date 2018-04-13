using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;
using Sneaker.Repositories.Interfaces;
using Sneaker.Context;
using Microsoft.EntityFrameworkCore;

namespace Sneaker.Repositories
{
    public class MaterialRepository : IRepository<Material>
    {
        private readonly ModelContext db;
        public MaterialRepository(ModelContext model)
        {
            db = model;
        }

        public IEnumerable<Material> GetAll => db.Materials;

        public void Create(Material material)
        {
            db.Materials.Add(material);
        }

        public void Delete(int? id)
        {
            Material material = db.Materials.Find(id);
            if (material != null)
                db.Materials.Remove(material);
        }

        public Material Get(int id)
        {
            return db.Materials.Find(id);
        }

        public void Edit(Material material)
        {
            db.Entry(material).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
