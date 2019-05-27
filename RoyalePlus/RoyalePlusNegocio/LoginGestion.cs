using RoyalePlusDatos.BD;
using RoyalePlusDatos.DTO;

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalePlusNegocio
{
    public class LoginGestion
    {
        public RespuestaGenerica login(Usuario usuario)
        {
            try
            {
                using (var ctx = new ROYALEPLUSEntities())
                {
                    ObjectParameter paramMENSAJE = new ObjectParameter("MENSAJE", typeof(string));
                    ObjectParameter paramRETCODE = new ObjectParameter("RETCODE", typeof(int));

                    ctx.PA_LOGIN(usuario.nombre, usuario.contrasena, paramRETCODE, paramMENSAJE);

                    if ((int)paramRETCODE.Value > 0)
                    {
                        return new RespuestaGenerica()
                        {
                            RetCode = (int)paramRETCODE.Value,
                            Mensaje = paramMENSAJE.Value.ToString()
                        };
                    }

                    if ((int)paramRETCODE.Value < 0)
                    {
                        throw new Exception(paramMENSAJE.Value.ToString());
                    }


                    return new RespuestaGenerica();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
