using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;
using Sneaker.Repositories.Interfaces;
using Sneaker.ViewModel;
using Sneaker.Context;
using Microsoft.EntityFrameworkCore;

namespace Sneaker.Repositories
{
    public class ImgRepository : IImageRepository
    {
        private readonly ModelContext db;
        public ImgRepository(ModelContext model)
        {
            db = model;
        }

        public IEnumerable<Img> GetAll => db.Imgs;

        public void Create(Img img)
        {
            db.Imgs.Add(img);
        }

        public void Delete(int? id)
        {
            Img img = db.Imgs.Find(id);
            if (img != null)
                db.Imgs.Remove(img);
        }

        public Img Get(int id)
        {
            return db.Imgs.Find(id);
        }

        public void Edit(Img img)
        {
            db.Entry(img).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public SneakerImg GetItemDb()
        {
            SneakerImg sneakerImg = new SneakerImg
            {
                Sneakers = db.Sneakers.ToList()
            };

            return sneakerImg;
        }
    }
}
