using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
    public class MemberController : Controller
    {
        private readonly Context context;
        public MemberController(Context context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var listOfMember = context.Members.ToList();
            return View(listOfMember);
        }

        //id sine göre üye bulma işlemi için action
        public IActionResult GetMember(int id)
        {
            var fetchMember = context.Members.Where(x => x.MEMBER_ID == id).FirstOrDefault();
            return View("UpdateMember", fetchMember);
        }

        //üye bilgilerini güncelleme işlemi için action
        public IActionResult UpdateMember(Member member)
        {
            var fetchMember = context.Members.Where(x => x.MEMBER_ID == member.MEMBER_ID).FirstOrDefault();
            fetchMember.NAMESURNAME = member.NAMESURNAME;
            fetchMember.MAIL = member.MAIL;
            //fetchMember.PASSWORD = member.PASSWORD;
            fetchMember.AGE = member.AGE;
            fetchMember.PHONENUMBER = member.PHONENUMBER;
            fetchMember.ADDRESS = member.ADDRESS;
            fetchMember.ABOUT = member.ABOUT;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //member silme actionı
        public IActionResult DeleteMember(int id)
        {
            var fetchMember = context.Members.Where(x => x.MEMBER_ID == id).FirstOrDefault();
            context.Members.Remove(fetchMember);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
