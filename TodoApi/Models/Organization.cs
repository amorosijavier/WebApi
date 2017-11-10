using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Organization
    {
        //ID de la organizacion no visible para el usuario
        //Lave con auto incremento
        [Required]
        [Key]
        public int ID { get; set; }
        //nombre de la organizacion Requerido
        [Required]
        public string nombre { get; set; }
        //mail de la organizacion Requerido
        [Required]
        public string mail { get; set; }
        //Lista de Eventos asociados 
        public virtual List<Event> eventos { get; set; }
        //password de la organizacion 
        [Required]
        public string password { get; set; }
        //imagen de la organizacion 
        public string img { get; set; }



    }
}
