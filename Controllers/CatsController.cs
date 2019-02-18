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
        public ActionResult<IEnumerable<CatResult>> GetAll()
        {
            var list = _catsService.GetAllOrdered();
            return Ok(list);
        }

        [HttpGet("versus")]
        public ActionResult<IEnumerable<Cat>> GetVersus(){
            var list = _catsService.GetVersus();
            return Ok(list);
        }

        [HttpPut("vote/{id}")]
        public ActionResult Vote(string id){
            _catsService.VoteForCat(id);
            return Ok();
        }
    }
}
