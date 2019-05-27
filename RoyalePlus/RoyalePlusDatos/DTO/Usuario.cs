using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalePlusDatos.DTO
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string contrasena { get; set; }
        public string tipo { get; set; }
        public bool activo { get; set; }
        public string ultimaConexion { get; set; }
    }
}
