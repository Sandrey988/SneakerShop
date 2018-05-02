using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Context;

namespace Sneaker.Services.Interfaces
{
    public interface IServiceRepository
    {
        void SetStorageContext(IStorageContext storageContext);
    }
}
