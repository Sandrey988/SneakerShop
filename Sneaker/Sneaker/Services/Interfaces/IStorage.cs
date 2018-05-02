using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Repositories.Interfaces;
using Sneaker.Services.Interfaces;

namespace Sneaker.Services
{
    public interface IStorage
    {
        T GetRepository<T>() where T : IServiceRepository;
        void Save();
    }
}
