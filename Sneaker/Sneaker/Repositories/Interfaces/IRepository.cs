using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;
using Sneaker.ViewModel;

namespace Sneaker.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll { get; }
        T Get(int id);
        void Create(T item);
        void Edit(T item);
        void Delete(int? id);
        void Save();
    }
}
