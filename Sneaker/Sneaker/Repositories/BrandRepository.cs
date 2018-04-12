using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Context;
using Sneaker.Models;
using Sneaker.Repositories.Interfaces;

namespace Sneaker.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        private readonly ModelContext db;
        public BrandRepository(ModelContext model)
        {
            db = model;
        }
        
        public IEnumerable<Brand> GetAll => db.Brands;

        public void ConfirmDelete(int? id)
        {
            throw new NotImplementedException();
        }

        public void Create(Brand item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Brand Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Edit(Brand item)
        {
            throw new NotImplementedException();
        }
    }
}
