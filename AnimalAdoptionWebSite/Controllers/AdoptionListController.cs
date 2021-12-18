using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
    public class AdoptionListController : Controller
    {
        private readonly Context context;

        public AdoptionListController(Context context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var ListOfAnimal = context.Adoptions
                .Include(m => m.Member)
                .Include(a => a.Animal)
                .ToList();
            return View(ListOfAnimal);
        }
    }
}
