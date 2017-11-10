using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Event
    {
        //ID del evento
        public int ID { get; set; }
        //fecha de inicio
        public DateTime _inicio { get; set; }
        //fecha de fin de evento
        public DateTime _fin { get; set; }
        //nombre de evento
        public string nombre { get; set; }
        //ruta de la imagen
        public string img { get; set; }
        //ForeignKey
        public int organizacionID { get; set; }
        //descripcion del evento
        public string description { get; set; }

    }
}
