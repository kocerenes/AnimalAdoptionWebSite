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
            return RedirectToAction("Index");
        }

        //Türü silmek için action
        public IActionResult DeleteKind(int id)
        {
            var fetchKind = context.Kinds.Where(x => x.KIND_ID == id).FirstOrDefault();
            context.Kinds.Remove(fetchKind);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //id sini verdiğimizde, kind bulması için gereken action
        public IActionResult GetKind(int id)
        {
            var fetchKind = context.Kinds.Where(x => x.KIND_ID == id).FirstOrDefault();
            return View("UpdateKind", fetchKind);
        }

        //tür adını güncellemek için action
        public IActionResult UpdateKind(Kind kind)
        {
            var fetchKind = context.Kinds.Where(x => x.KIND_ID == kind.KIND_ID).FirstOrDefault();
            fetchKind.TYPE_NAME = kind.TYPE_NAME;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
