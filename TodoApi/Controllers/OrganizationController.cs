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
        public Organization Get(int id)
        {
            Organization toR = _context.OrganizationItems.SingleOrDefault(c => c.ID == id);
            if (toR == null)
                throw new NullReferenceException(); //Chequear en futuros refactorings
            return toR;
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
        public void Put(int id, [FromBody]Organization org)
        {
            Organization toModify = _context.OrganizationItems.SingleOrDefault(c => c.ID == id);
            if (toModify == null)
                throw new NullReferenceException();//codigo a revisar en futuros refactorings
            toModify.eventos = org.eventos;//Còdigo A revisar en futuros refactorings
            toModify.img = org.img;
            toModify.mail = org.mail;
            toModify.nombre = org.nombre;
            toModify.password = org.password;
            

            //guardo los cambios en la base de datos...

            _context.SaveChanges();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Organization toR = _context.OrganizationItems.SingleOrDefault(c => c.ID == id);
            _context.OrganizationItems.Remove(toR);
            _context.SaveChanges();
        }
    }
}
