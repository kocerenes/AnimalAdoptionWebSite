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
        public async Task<IActionResult> Index(Admin admin = null, Member member = null)
        {
            var fetchAdmin = context.Admins.FirstOrDefault(x => x.MAIL == admin.MAIL && x.PASSWORD == admin.PASSWORD);
            var fetchMember = context.Members.FirstOrDefault(x => x.MAIL == member.MAIL && x.PASSWORD == member.PASSWORD);
            if (fetchAdmin != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.MAIL)
                };
                var adminIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(adminIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Animal");
            }
            else if (fetchMember != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,member.MAIL)
                };
                var memberIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(memberIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "MemberPage");
            }
            else
            {
                //TempData["error"] = "Bilgileriniz eksik veya hatali. Lutfen kontrol edin!";
                return View();
            }
        }

        //Oturum kapatma işlemi
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
