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
    public class SneakerController : Controller
    {
        private readonly ISneakerRepository<Models.Sneaker> br;

        public SneakerController(ISneakerRepository<Models.Sneaker> sneakerRepository)
        {
            br = sneakerRepository;
        }
        public IActionResult Index()
        {
            return View(br.GetAll);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SneakerAll sneakerAll = br.GetItemDb();
            return View(sneakerAll);
        }

        [HttpPost]
        public IActionResult Create(Models.Sneaker sneaker, SneakerAll sneakerAll)
        {
            if (string.IsNullOrEmpty(sneakerAll.Name))
            {
                ModelState.AddModelError("Name", "");
            }
            else if (string.IsNullOrEmpty(sneakerAll.Descriptions))
            {
                ModelState.AddModelError("Descriptions", "");
            }

            if (ModelState.IsValid)
            {
                sneaker.SneakerId = sneakerAll.Id;
                sneaker.Description = sneakerAll.Descriptions;
                sneaker.SneakerName = sneakerAll.Name;
                sneaker.CategoryId = sneakerAll.SelectedCategory;
                sneaker.MaterialId = sneakerAll.SelectedMaterial;
                sneaker.BrandId = sneakerAll.SelectedBrand;
                br.Create(sneaker);
                br.Save();
                return RedirectToAction("Index");
            }

            return View(sneakerAll);
        }

        public IActionResult Delete(int id)
        {
            Models.Sneaker sneaker = br.Get(id);
            return View(sneaker);
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