using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
    public class KindController : Controller
    {
        private readonly Context context;

        public KindController(Context context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var listOfKind = context.Kinds.ToList();
            return View(listOfKind);
        }

        //Yeni tür eklemek için action
        [HttpGet]
        public IActionResult AddKind()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddKind(Kind kind)
        {
            context.Kinds.Add(kind);
            context.SaveChanges();
            return View();
        }

        //Türü silmek için action
        [HttpGet]
        public IActionResult DeleteKind()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteKind(int? id)
        {
            var kind = context.Kinds.Find(id);
            context.Kinds.Remove(kind);
            context.SaveChanges();
            return View();
        }
    }
}
