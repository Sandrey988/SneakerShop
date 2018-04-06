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
    public class SneakerController : Controller
    {
        private ModelContext db;

        public SneakerController(ModelContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Sneakers.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            SneakerAll sneakerAll = new SneakerAll
            {
                Brands = db.Brands.ToList(),
                Categories = db.Categories.ToList(),
                Materials = db.Materials.ToList()
            };

            return View(sneakerAll);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SneakerAll sneakerAll, Models.Sneaker sneaker)
        {
            sneaker.SneakerId = sneakerAll.Id;
            sneaker.Description = sneakerAll.Descriptions;
            sneaker.SneakerName = sneakerAll.Name;
            sneaker.CategoryId = sneakerAll.SelectedCategory;
            sneaker.MaterialId = sneakerAll.SelectedMaterial;
            sneaker.BrandId = sneakerAll.SelectedBrand;


            db.Sneakers.Add(sneaker);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Models.Sneaker sneaker = await db.Sneakers.FirstOrDefaultAsync(p => p.SneakerId == id);
                if (sneaker != null)
                    return View(sneaker);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id != null)
            {
                Models.Sneaker sneaker = await db.Sneakers.FirstOrDefaultAsync(p => p.SneakerId == id);
                if (sneaker != null)
                    return View(sneaker);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Sneaker sneaker)
        {

            db.Sneakers.Update(sneaker);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Models.Sneaker sneaker = await db.Sneakers.FirstOrDefaultAsync(p => p.SneakerId == id);
                if (sneaker != null)
                    return View(sneaker);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Models.Sneaker sneaker = new Models.Sneaker { SneakerId = id.Value };
                db.Entry(sneaker).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}