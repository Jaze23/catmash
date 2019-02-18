using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMash.Models;
using CatMash.Services.Cats;
using Microsoft.AspNetCore.Mvc;

namespace CatMash.Controllers
{
    [Route("api/[controller]")]
    public class CatsController : Controller
    {
        private readonly ICatsService _catsService;
        public CatsController(ICatsService catsService){
            _catsService = catsService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Cat>> GetAll()
        {
            var list = _catsService.GetAll();
            return Ok(list);
        }
    }
}
