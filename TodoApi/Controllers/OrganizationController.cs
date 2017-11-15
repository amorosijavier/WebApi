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
    public class OrganizationController : Controller
    {
        private readonly TodoContext _context;


        public OrganizationController(TodoContext context)
        {
            _context = context;

            if (_context.EventItems.Count() == 0)
            {
                Organization toAdd = new Organization();
                toAdd.nombre = "Union Industrial";
                toAdd.mail = "uibb@gmail.com";
                toAdd.password = "asd123";
                toAdd.eventos = null;
                _context.OrganizationItems.Add(toAdd);
                _context.SaveChanges();
            }
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Organization> Get()
        {
            return _context.OrganizationItems.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        public IActionResult Create([FromBody]Organization item)
        {
            try {
                //si el item es nulo lo procesa como badRequest
                if (item == null)
                {
                    return BadRequest();
                }
                //agrega el item evento a la base de datos
                _context.OrganizationItems.Add(item);
                _context.SaveChanges();

                return CreatedAtRoute("GetTodo", new { id = item.ID }, item);

            }
            catch(Exception e){
                return BadRequest("Error al crear la clave");

            }
           

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
