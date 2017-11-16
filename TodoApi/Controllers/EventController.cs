using System;
using System.Collections.Generic;
using System.Linq;
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
                //Codigo a ser eliminado en futuros refactorings
                Event toAdd = new Event();
                toAdd.nombre = "pelicula";
                _context.EventItems.Add(toAdd);
                _context.SaveChanges();
            }
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Event> GetEvents()
        {
            return _context.EventItems.ToList();
        }
        //Arroja la excepcion si no encuentra el Evento con el Id seleccionado...Revisar Metodo. 
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Event toR = _context.EventItems.SingleOrDefault(c => c.ID == id);
            if (toR == null)
                return NotFound();
            return new ObjectResult(toR);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Event item)
        {
            //si el item es nulo lo procesa como badRequest
            if (item == null)
                return BadRequest();
            
            //agrega el item evento a la base de datos
            _context.EventItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id =item.ID }, item);

        }
        //Actualizo los campos del Evento dado. 
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Event item)
        {
            //Si no existe Evento con el id dado en la base de datos
            Event toModify = _context.EventItems.SingleOrDefault(c => c.ID == id);
            if (toModify == null)
                return NotFound();
            //Si nos pasan un evento con un parametro nulo
            if (item == null)
                return BadRequest();
            toModify.nombre = item.nombre;
            toModify.organizacionID = item.organizacionID;//No debe de ser necesario, linea a eliminar en proximos refactorings
            toModify.img = item.img;
            toModify._inicio = item._inicio;
            toModify._fin = item._fin;
            toModify.description = item.description;

            //guardo los cambios en la base de datos...
            _context.EventItems.Update(toModify);
            _context.SaveChanges();
            return new NoContentResult();


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Event toRemove = _context.EventItems.SingleOrDefault(c => c.ID == id);
            //Si el evento con el id dado no se encuentra en la base de datos.
            if (toRemove == null)
                return NotFound();
            _context.EventItems.Remove(toRemove);
            _context.SaveChanges();
            return new NoContentResult();
           
        }
    }
}
