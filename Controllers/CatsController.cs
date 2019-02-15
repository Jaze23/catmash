using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMash.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatMash.Controllers
{
    [Route("api/[controller]")]
    public class CatsController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Cat>> GetAll()
        {
            var list = new List<Cat>() { new Cat(){ Id = 1, Url = "Allo"}}.AsEnumerable();
            return Ok(list);
        }
    }
}
