using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
