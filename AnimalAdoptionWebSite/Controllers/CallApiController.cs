using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
    public class CallApiController : Controller
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<IActionResult> Index(int id)
        {
            List<Animal> fetchAnimal = new List<Animal>();
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:44312/api/AnimalDetailsApi");
            string apiResponse = await response.Content.ReadAsStringAsync();
            fetchAnimal = JsonConvert.DeserializeObject<List<Animal>>(apiResponse);
            Animal str = fetchAnimal.Where(x => x.ANIMAL_ID == id).FirstOrDefault();
            return View(str);
        }
    }
}
