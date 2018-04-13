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

namespace Sneaker.Controllers.AdminControllers
{
    public class MaterialController : Controller
    {

        private readonly IRepository<Material> br;

        public MaterialController(IRepository<Material> materialRepository)
        {
            br = materialRepository;
        }

        public ViewResult Index()
        {
            return View(br.GetAll);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Material material)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        br.Create(material);
        //        br.Save();
        //        return RedirectToAction("Index");
        //    }

        //    return View(material);
        //}


        //public IActionResult Edit(int id)
        //{
        //    Material material = br.Get(id);
        //    return View(material);
        //}

        //[HttpPost]
        //public IActionResult Edit(Material material)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        br.Edit(material);
        //        br.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(material);
        //}

        //public IActionResult Delete(int id)
        //{
        //    Material material = br.Get(id);
        //    return View(material);
        //}


        //[HttpPost]
        //public IActionResult Delete(int? id)
        //{
        //    if (id != null)
        //    {
        //        br.Delete(id);
        //        br.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return NotFound();
        //}
    }
}