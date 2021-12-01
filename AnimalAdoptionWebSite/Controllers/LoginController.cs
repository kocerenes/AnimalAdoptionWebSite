using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly Context context;
        public LoginController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {
            var fetchAdmin = context.Admins.FirstOrDefault(x => x.MAIL == admin.MAIL && x.PASSWORD == admin.PASSWORD);
            if (fetchAdmin != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.MAIL)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Animal");
            }
            else
            {
                return View();
            }

        }

    }
}
