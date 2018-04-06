using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sneaker.Models;
using Sneaker.ViewModel;

namespace Sneaker.Controllers.AdminControllers
{
    public class ImgController : Controller
    {
        private ModelContext db;

        public ImgController(ModelContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Imgs.ToListAsync());
        }

        public IActionResult Create()
        {
            SneakerImg sneakerImg = new SneakerImg
            {
                Sneakers = db.Sneakers.ToList()
            };

            return View(sneakerImg);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SneakerImg sneakerImg, Img img)
        {
            img.ImgUrl = sneakerImg.UrlImage;
            img.SneakerId = sneakerImg.SelectSneaker;
            db.Imgs.Add(img);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Img img = await db.Imgs.FirstOrDefaultAsync(p => p.Id == id);
                if (img != null)
                    return View(img);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Img img = await db.Imgs.FirstOrDefaultAsync(p => p.Id == id);
                if (img != null)
                    return View(img);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Img img)
        {
            db.Imgs.Update(img);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Img img = await db.Imgs.FirstOrDefaultAsync(p => p.Id == id);
                if (img != null)
                    return View(img);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Img img = new Img { Id = id.Value };
                db.Entry(img).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}