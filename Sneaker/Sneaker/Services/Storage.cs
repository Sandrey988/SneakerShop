using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Services.Interfaces;
using Sneaker.Context;
using Sneaker.Models;
using System.Reflection;

namespace Sneaker.Services
{
    public class Storage 
    {
        public ModelContext db;

        public Storage(ModelContext modelContext)
        {
            db = modelContext;
        }

        public T GetRepository<T>() where T : IServiceRepository
        {
            foreach (Type type in this.GetType().GetTypeInfo().Assembly.GetTypes())
            {
                if (typeof(T).GetTypeInfo().IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
                {
                    T repository = (T)Activator.CreateInstance(type);
                    return repository;
                }
            }
            return default(T);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
