using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sneaker.Models;
using Microsoft.EntityFrameworkCore;
using Sneaker.Context;

namespace Sneaker.Controllers.AdminControllers
{
    public class IndexController : Controller
    {
        [Route("Admin/Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}