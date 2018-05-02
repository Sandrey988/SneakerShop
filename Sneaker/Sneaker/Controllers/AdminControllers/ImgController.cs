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
    public class ImgController : Controller
    {
        private readonly IImageRepository br;

        public ImgController(IImageRepository imgRepository)
        {
            br = imgRepository;
        }
        public IActionResult Index()
        {
            return View(br.GetAll);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            SneakerImg sneakerImg = br.GetItemDb();
            return View(sneakerImg);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Img img, SneakerImg sneakerImg)
        {
            img.ImgUrl = sneakerImg.UrlImage;
            img.SneakerId = sneakerImg.SelectSneaker;

            if (ModelState.IsValid)
            {
                br.Create(img);
                br.Save();
                return RedirectToAction("Index");
            }

            return View(img);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Img img = br.Get(id);
            return View(img);
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