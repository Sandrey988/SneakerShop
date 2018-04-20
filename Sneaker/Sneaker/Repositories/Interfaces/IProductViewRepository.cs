using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;
using Sneaker.ViewModel;

namespace Sneaker.Repositories.Interfaces
{
    public interface IProductViewRepository
    {
        void GetProductElement(int id);
        Brand Get( int id);
    }
}
