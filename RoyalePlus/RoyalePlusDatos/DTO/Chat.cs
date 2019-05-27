using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalePlusDatos.DTO
{
    public class Chat
    {
        public Chat()
        {

        }
        public int idChat { get; set; }
        public string ultimoMensaje { get; set; }
        public DateTime ultimoTiempo { get; set; }
        public string ultimoEnHablar { get; set; }
        public string nombreChat { get; set; }
        public string tipoChat { get; set; }
        public int mensajesSinLeer { get; set; }
        public string imagen { get; set; }
        public string tipoImagen { get; set; }
        public int idContrario { get; set; }
        public int idUsuario { get; set; }
    }
}
