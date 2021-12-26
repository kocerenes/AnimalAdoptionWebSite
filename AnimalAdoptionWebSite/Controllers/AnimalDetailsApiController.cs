using AnimalAdoptionWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalDetailsApiController : ControllerBase
    {
        // GET: api/<AnimalDetailsApiController>
        private readonly Context context;

        public AnimalDetailsApiController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Animal> Get()
        {
            return context.Animals.ToList();
        }        
    }
}
