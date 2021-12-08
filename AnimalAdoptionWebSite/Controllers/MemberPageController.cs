using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
    public class MemberPageController : Controller
    {
        private readonly IHtmlLocalizer<MemberPageController> _localizer;
        private readonly Context context;

        public MemberPageController(Context context, IHtmlLocalizer<MemberPageController> localizer)
        {
            this.context = context;
            _localizer = localizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ListOfAnimal = context.Animals.Where(x => x.STATUS == true).ToList();
            return View(ListOfAnimal);
        }

        [HttpPost, AllowAnonymous]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return LocalRedirect(returnUrl);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var fetchMemberMail = User.Identity.Name; //önce giriş yapanın mailini aldım
            //giriş yapanın mailinden ID sine ulaştım 
            var fetchMemberID = context.Members.Where(x => x.MAIL == fetchMemberMail).Select(y => y.MEMBER_ID).FirstOrDefault();
            //Id sini bildiğim üye nesnesini aldım
            var fetchMember = context.Members.Where(x => x.MEMBER_ID == fetchMemberID).FirstOrDefault();
            ViewBag.NameSurname = fetchMember.NAMESURNAME; //giriş yapanın isim soyismini viewbage aldım
            return View(fetchMember);
        }
        [HttpPost]
        public IActionResult Profile(Member member)
        {
            var fetchMember = context.Members.Where(x => x.MEMBER_ID == member.MEMBER_ID).FirstOrDefault();
            fetchMember.MAIL = member.MAIL;
            fetchMember.PASSWORD = member.PASSWORD;
            fetchMember.PHONENUMBER = member.PHONENUMBER;
            fetchMember.ADDRESS = member.ADDRESS;
            fetchMember.ABOUT = member.ABOUT;
            context.SaveChanges();
            return RedirectToAction("Index", "MemberPage");
        }

        //üyenin sahiplenme işlemi için oluşturduğum action
        public IActionResult CreateAdoption(int id)
        {
            var fetchMemberMail = User.Identity.Name; //önce giriş yapanın mailini aldım
            //giriş yapanın mailinden ID sine ulaştım 
            var fetchMemberID = context.Members.Where(x => x.MAIL == fetchMemberMail).Select(y => y.MEMBER_ID).FirstOrDefault();

            //sahiplenlen hayvanın durumunu false yapabilmek için gelen id ile animal nesnesini aldım
            var fetchAnimal = context.Animals.Where(x => x.ANIMAL_ID == id).FirstOrDefault();

            Adoption adoption = new Adoption();
            adoption.ANIMAL_ID = id;
            adoption.MEMBER_ID = fetchMemberID;
            adoption.DATE = DateTime.Now;
            fetchAnimal.STATUS = false; //hayvanın durumunu false yaptım
            context.Adoptions.Add(adoption);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //kullanıcının sahiplenmelerine bakmasını sağlayan action
        public IActionResult ListOfAdoption()
        {
            var fetchMemberMail = User.Identity.Name; //önce giriş yapanın mailini aldım
            //giriş yapanın mailinden ID sine ulaştım 
            var fetchMemberID = context.Members.Where(x => x.MAIL == fetchMemberMail).Select(y => y.MEMBER_ID).FirstOrDefault();

            var listOfAdoption = context.Adoptions
                .Include(y => y.Member)
                .Include(z => z.Animal)
                .Where(x => x.MEMBER_ID == fetchMemberID)
                .ToList();
            return View(listOfAdoption);
        }

        public IActionResult DetailsOfAnimal(int id)
        {
            var fetchAnimalName = context.Animals.Where(x => x.ANIMAL_ID == id).Select(y => y.NAME).FirstOrDefault();
            ViewBag.animalName = fetchAnimalName;
            var fetchAnimal = context.Animals.Include(y=>y.Kind).Where(x => x.ANIMAL_ID == id).FirstOrDefault();
            return View(fetchAnimal);
        }
    }
}
