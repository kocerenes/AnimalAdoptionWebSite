using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context context;
        public HomeController(Context context)
        {
            this.context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var ListOfAnimal = context.Animals.Where(x => x.STATUS == true).ToList();
            return View(ListOfAnimal);
        }
    }
}
