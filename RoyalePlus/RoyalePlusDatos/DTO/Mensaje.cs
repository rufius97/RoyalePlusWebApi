using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalePlusDatos.DTO
{
    public class Mensaje
    {
        public Mensaje()
        {

        }
        public int idMensaje { get; set; }
        public int idChat { get; set; }
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public DateTime tiempo { get; set; }
        public bool leido { get; set; }
        public string mensaje { get; set; }
        public string tipo { get; set; }
    }
}
