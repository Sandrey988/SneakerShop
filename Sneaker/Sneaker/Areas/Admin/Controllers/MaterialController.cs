using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sneaker.Models;
using Sneaker.Repositories.Interfaces;
using Sneaker.ViewModel;
using Sneaker.Repositories;
using Microsoft.EntityFrameworkCore;
using Sneaker.Context;
using Microsoft.AspNetCore.Authorization;

namespace Sneaker.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class MaterialController : Controller
    {
        private readonly IRepository<Material> br;

        public MaterialController(IRepository<Material> categoryRepository)
        {
            br = categoryRepository;
        }

        public async Task<ViewResult> Index()
        {
            return View(br.GetAll);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Material material)
        {

            if (ModelState.IsValid)
            {
                br.Create(material);
                br.Save();
                return RedirectToAction("Index");
            }

            return View(material);
        }


        public async Task<IActionResult> Edit(int id)
        {
            Material material = br.Get(id);
            return View(material);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Material material)
        {
            if (ModelState.IsValid)
            {
                br.Edit(material);
                br.Save();
                return RedirectToAction("Index");
            }
            return View(material);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Material material = br.Get(id);
            return View(material);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                br.Delete(id);
                br.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}