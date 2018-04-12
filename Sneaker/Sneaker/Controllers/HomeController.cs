using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sneaker.Models;
using Microsoft.AspNetCore.Mvc;
using Sneaker.ViewModel;

namespace Sneaker.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
