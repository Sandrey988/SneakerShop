using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.ViewModel;

namespace Sneaker.Repositories.Interfaces
{
    public interface ISneakerRepository<T> where T : class
    {
        IEnumerable<T> GetAll { get; } 
        T Get(int id);
        void Create(T item, SneakerAll sneakerAll);
        void Edit(T item);
        void Delete(int? id);
        void Save();
        SneakerAll GetItemDb();
    }
}
