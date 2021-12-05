using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
    public class AnimalController : Controller
    {
        private readonly Context context;

        public AnimalController(Context context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var listOfAnimals = context.Animals.Include(x=>x.Kind).ToList();
            return View(listOfAnimals);
        }

        //Yeni hayvan eklemek için action
        [HttpGet]
        public IActionResult AddAnimal()
        {
            List<SelectListItem> valuesKind = (from k in context.Kinds.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = k.TYPE_NAME,
                                                       Value = k.KIND_ID.ToString()
                                                   }).ToList();
            ViewBag.fetchKindList = valuesKind;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAnimal(Animal animal)
        {
            //var fetchKind = context.Kinds.Where(x => x.KIND_ID == animal.Kind.KIND_ID).FirstOrDefault();
            //animal.Kind = fetchKind;
            context.Animals.Add(animal);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //animal silme action ı
        public IActionResult DeleteAnimal(int id)
        {
            var fetchAnimal = context.Animals.Where(x => x.ANIMAL_ID == id).FirstOrDefault();
            context.Animals.Remove(fetchAnimal);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //id sini verdiğimizde, animal bulması için gereken action
        public IActionResult GetAnimal(int id)
        {
            var fetchAnimal = context.Animals.Where(x => x.ANIMAL_ID == id).FirstOrDefault();
            return View("UpdateAnimal", fetchAnimal);
        }

        //animal değerlerini güncellemek için action
        public IActionResult UpdateAnimal(Animal animal)
        {
            var fetchAnimal = context.Animals.Where(x => x.ANIMAL_ID == animal.ANIMAL_ID).FirstOrDefault();
            fetchAnimal.NAME = animal.NAME;
            fetchAnimal.GENUS = animal.GENUS;
            fetchAnimal.AGE = animal.AGE;
            fetchAnimal.CITY = animal.CITY;
            fetchAnimal.STATUS = animal.STATUS;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
