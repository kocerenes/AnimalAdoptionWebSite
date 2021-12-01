﻿using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
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
            //if (string.IsNullOrEmpty(member.PHONENUMBER))
            //{
            //    member.PHONENUMBER = "---";
            //}
            //if (string.IsNullOrEmpty(member.ABOUT))
            //{
            //    member.ABOUT = "---";
            //}
            context.Members.Add(member);
            context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
