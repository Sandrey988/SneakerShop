using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sneaker.Models;
using Sneaker.ViewModel;
using Sneaker.Context;

namespace Sneaker.Controllers.AdminControllers
{
    public class SizeController : Controller
    {
        private ModelContext db;

        public SizeController(ModelContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Sizes.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Size size)
        {
            db.Sizes.Add(size);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Size size = await db.Sizes.FirstOrDefaultAsync(p => p.SizeId == id);
                if (size != null)
                    return View(size);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Size size = await db.Sizes.FirstOrDefaultAsync(p => p.SizeId == id);
                if (size != null)
                    return View(size);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Size size)
        {
            db.Sizes.Update(size);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Size size = await db.Sizes.FirstOrDefaultAsync(p => p.SizeId == id);
                if (size != null)
                    return View(size);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Size size = new Size { SizeId = id.Value };
                db.Entry(size).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}