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
using Sneaker.Repositories.Interfaces;


namespace Sneaker.Controllers.AdminControllers
{
    public class SizeController : Controller
    {
        private readonly IRepository<Size> br;

        public SizeController(IRepository<Size> sizeRepository)
        {
            br = sizeRepository;
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
        public IActionResult Create(Size size)
        {
            if (ModelState.IsValid)
            {
                br.Create(size);
                br.Save();
                return RedirectToAction("Index");
            }

            return View(size);
        }


        public IActionResult Edit(int id)
        {
            Size size = br.Get(id);
            return View(size);
        }

        [HttpPost]
        public IActionResult Edit(Size size)
        {
            if (ModelState.IsValid)
            {
                br.Edit(size);
                br.Save();
                return RedirectToAction("Index");
            }
            return View(size);
        }

        public IActionResult Delete(int id)
        {
            Size size = br.Get(id);
            return View(size);
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