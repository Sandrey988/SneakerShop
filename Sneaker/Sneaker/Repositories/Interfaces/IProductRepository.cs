using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.ViewModel;
using Sneaker.Models;

namespace Sneaker.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll { get; }
        Product Get(int id);
        void Create(Product item);
        void Edit(Product item);
        void Delete(int? id);
        void Save();
        ProductSneaker GetItemDb();
    }
}
