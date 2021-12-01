﻿using AnimalAdoptionWebSite.Models;
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

        public IActionResult Index()
        {
            var ListOfAnimal = context.Animals.Where(x => x.STATUS == true).ToList();
            return View(ListOfAnimal);
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
