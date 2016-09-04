using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RatingApp.Models;

namespace RatingApp.Controllers
{
    [Route("api/[controller]")]
    public class RatingsController : Controller
    {
        DataManager _dataManager = new DataManager();

        // GET api/ratings
        [HttpGet]
        public IEnumerable<Rating> Get()
        {
            return _dataManager.GetAll();
        }

        // GET api/ratings/5
        [HttpGet("{id}", Name = "GetRating")]
        public IActionResult Get(int id)
        {
            var item = _dataManager.GetById(id);
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
            _dataManager.Add(item);
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

            var tmpItem = _dataManager.GetById(id);
            if (tmpItem == null)
            {
                return NotFound();
            }

            _dataManager.Update(item);
            return new NoContentResult();
        }

        // DELETE api/ratings/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _dataManager.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            _dataManager.Remove(id);
            return new NoContentResult();
        }
    }
}
