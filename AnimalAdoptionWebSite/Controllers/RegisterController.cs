using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly Context context;
        public RegisterController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Member member)
        {
            context.Members.Add(member);
            context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
