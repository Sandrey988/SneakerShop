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
            if (ModelState.IsValid)
            {
                br.Create(sneaker, sneakerAll);
                br.Save();
                return RedirectToAction("Index");
            }

            return View(sneaker);
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