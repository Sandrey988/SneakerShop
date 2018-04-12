using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Context;
using Sneaker.Models;

namespace Sneaker.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ModelContext db;
        public BrandRepository(ModelContext model)
        {
            db = model;
        }
        public IEnumerable<Brand> Brands => db.Brands;
    }
}
