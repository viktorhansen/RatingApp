using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using RatingApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.OData;

namespace RatingApp.Controllers
{
    // Sets CORS config to global for entire controller
    [EnableCors("AllowAnyOrigin")]
    // route for controller: api/ratings
    [Route("api/[controller]")]
    public class RatingsController : Controller
    {
        // Using the interface
        public IRatingsRepository RatingsRepo { get; set; }

        public RatingsController(IRatingsRepository repo)
        {
            RatingsRepo = repo;
        }

        // GET api/ratings
        [HttpGet]
        public IEnumerable<Rating> Get()
        {
            return RatingsRepo.GetAll();
        }

        // GET api/ratings/5
        [HttpGet("{id}", Name = "GetRating")]
        public IActionResult Get(int id)
        {
            var item = RatingsRepo.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/ratings
        [HttpPost]
        public IActionResult Post([FromBody]Rating item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            RatingsRepo.Add(item);
            return CreatedAtRoute("GetRating", new { id = item.Id }, item);
        }

        // PUT api/ratings/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Rating item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var tmpItem = RatingsRepo.GetById(id);
            if (tmpItem == null)
            {
                return NotFound();
            }

            RatingsRepo.Update(item);
            return new NoContentResult();
        }

        // DELETE api/ratings/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = RatingsRepo.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            RatingsRepo.Remove(id);
            return new NoContentResult();
        }
    }
}
