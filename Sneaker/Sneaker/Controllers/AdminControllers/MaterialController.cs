using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sneaker.Models;

namespace Sneaker.Controllers.AdminControllers
{
    public class MaterialController : Controller
    {
        private ModelContext db;

        public MaterialController(ModelContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Materials.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Material material)
        {
            db.Materials.Add(material);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Material material = await db.Materials.FirstOrDefaultAsync(p => p.Id == id);
                if (material != null)
                    return View(material);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Material material = await db.Materials.FirstOrDefaultAsync(p => p.Id == id);
                if (material != null)
                    return View(material);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Material material)
        {
            db.Materials.Update(material);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Material material = await db.Materials.FirstOrDefaultAsync(p => p.Id == id);
                if (material != null)
                    return View(material);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Material material = new Material { Id = id.Value };
                db.Entry(material).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}