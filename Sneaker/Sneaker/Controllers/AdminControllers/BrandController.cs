using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sneaker.Models;
using Microsoft.EntityFrameworkCore;
using Sneaker.Context;

namespace Sneaker.Controllers.AdminControllers
{
    public class BrandController : Controller
    {
        private ModelContext db;

        public BrandController(ModelContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Brands.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            db.Brands.Add(brand);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Brand brand = await db.Brands.FirstOrDefaultAsync(p => p.Id == id);
                if (brand != null)
                    return View(brand);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Brand brand = await db.Brands.FirstOrDefaultAsync(p => p.Id == id);
                if (brand != null)
                    return View(brand);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Brand brand)
        {
            db.Brands.Update(brand);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Brand brand = await db.Brands.FirstOrDefaultAsync(p => p.Id == id);
                if (brand != null)
                    return View(brand);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Brand brand = new Brand { Id = id.Value };
                db.Entry(brand).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}