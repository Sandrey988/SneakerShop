using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;

namespace Sneaker.Repositories
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetBrand { get; }

    }
}
