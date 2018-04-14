using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;
using Sneaker.ViewModel;

namespace Sneaker.Repositories.Interfaces
{
    public interface IImageRepository
    {
        IEnumerable<Img> GetAll { get; }
        Img Get(int id);
        void Create(Img item);
        void Edit(Img item);
        void Delete(int? id);
        void Save();
        SneakerImg GetItemDb();
    }
}
