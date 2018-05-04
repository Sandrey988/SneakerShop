using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sneaker.Models;
using Microsoft.EntityFrameworkCore;
using Sneaker.Context;
using Microsoft.AspNetCore.Authorization;

namespace Sneaker.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}