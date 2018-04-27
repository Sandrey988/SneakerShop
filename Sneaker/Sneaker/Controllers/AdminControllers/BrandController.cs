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

namespace Sneaker.Controllers.AdminControllers
{
    public class BrandController : Controller
    {
        private readonly IRepository<Brand> br;

        public BrandController(IRepository<Brand> brandRepository)
        {
            br = brandRepository;
        }


        public ViewResult Index()
        {
            return View(br.GetAll);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (string.IsNullOrEmpty(brand.BrandName))
            {
                ModelState.AddModelError("BrandName", "Некорректное имя");
            }
            else if (string.IsNullOrEmpty(brand.Description))
            {
                ModelState.AddModelError("Description", "Некорректное описание");
            }


            if (ModelState.IsValid)
            {
                br.Create(brand);
                br.Save();
                return RedirectToAction("Index");
            }

            return View(brand);
        }


        public IActionResult Edit(int id)
        {
            Brand brand = br.Get(id);
            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                br.Edit(brand);
                br.Save();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        public IActionResult Delete(int id)
        {
            Brand brand = br.Get(id);
            return View(brand);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
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