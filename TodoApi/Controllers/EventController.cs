using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
 
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly TodoContext _context;


        public EventController(TodoContext context)
        {
            _context = context;

            if (_context.EventItems.Count() == 0)
            {
                Event toAdd = new Event();
                toAdd.nombre = "pelicula";
                _context.EventItems.Add(toAdd);
                _context.SaveChanges();
            }
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.EventItems.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Event item)
        {
            //si el item es nulo lo procesa como badRequest
            if (item == null)
            {
                return BadRequest();
            }
            //agrega el item evento a la base de datos
            _context.EventItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id =item.ID }, item);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
