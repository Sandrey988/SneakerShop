using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sneaker.Models;
using Sneaker.Context;
using Sneaker.Repositories.Interfaces;

namespace Sneaker.Controllers.AdminControllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> br;

        public CategoryController(IRepository<Category> categoryRepository)
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
        public async Task<IActionResult> Create(Category category)
        {

            if (ModelState.IsValid)
            {
                br.Create(category);
                br.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Category category = br.Get(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                br.Edit(category);
                br.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category category = br.Get(id);
            return View(category);
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