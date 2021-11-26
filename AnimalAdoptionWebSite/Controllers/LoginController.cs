using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Admin giriş
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(Admin admin)
        {

            return View();
        }

        //Üye Giriş
        [HttpGet]
        public IActionResult MemberLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MemberLogin(Member member)
        {

            return View();
        }
    }
}
