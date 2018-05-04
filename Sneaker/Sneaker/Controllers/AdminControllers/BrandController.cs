using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sneaker.Models;
using Microsoft.EntityFrameworkCore;
using Sneaker.Context;
using Sneaker.Repositories.Interfaces;
using Sneaker.Services;

namespace Sneaker.Controllers.AdminControllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IRepository<Brand> br;

        public BrandController(IRepository<Brand> brandRepository)
        {
            br = brandRepository;
        }
        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View(br.GetAll);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                br.Create(brand);
                br.Save();
                return RedirectToAction("Index");
            }

            return View(brand);
        }


        public async Task<IActionResult> Edit(int id)
        {
            Brand brand = br.Get(id);
            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                br.Edit(brand);
                br.Save();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Brand brand = br.Get(id);
            return View(brand);
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