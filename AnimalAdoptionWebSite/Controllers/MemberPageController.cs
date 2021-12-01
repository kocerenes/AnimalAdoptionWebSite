using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
    public class MemberPageController : Controller
    {
        private readonly Context context;
        public MemberPageController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ListOfAnimal = context.Animals.Where(x => x.STATUS == true).ToList();
            return View(ListOfAnimal);
        }
        [HttpPost]
        public IActionResult Index(Animal animal)
        {
            return View();
        }

        //giriş yapan üyeye ait bilgileri profil kısmına getirmek için yazdıgım actionlar
        [HttpGet]
        public IActionResult Profile()
        {
            var fetchMemberMail = User.Identity.Name; //önce giriş yapanın mailini aldım
            //giriş yapanın mailinden ID sine ulaştım 
            var fetchMemberID = context.Members.Where(x => x.MAIL == fetchMemberMail).Select(y => y.MEMBER_ID).FirstOrDefault();
            //Id sini bildiğim üye nesnesini aldım
            var fetchMember = context.Members.Where(x => x.MEMBER_ID == fetchMemberID).FirstOrDefault();
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
    }
}
