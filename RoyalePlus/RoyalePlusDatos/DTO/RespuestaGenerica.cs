using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalePlusDatos.DTO
{
    public class RespuestaGenerica
    {
        public int RetCode { get; set; }
        public string Mensaje { get; set; }

        public RespuestaGenerica()
        {
            RetCode = 0;
            Mensaje = "";
        }

    }
}
