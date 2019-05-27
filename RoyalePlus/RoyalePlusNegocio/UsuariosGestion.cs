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
    public class UsuariosGestion
    {
        public List<Usuario> TodosLosUsuarios()
        {
            // Insercion
            try
            {
                using (var ctx = new ROYALEPLUSEntities())
                {
                    var datos = ctx.USUARIOS.Select(s => new Usuario
                    {
                        idUsuario = s.ID_USUARIO,
                        nombre = s.NOMBRE,
                        contrasena = s.CONTRASENA,
                        tipo = s.TIPO,
                        activo = s.ACTIVO ?? false
                    });

                    var result = datos.ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new List<Usuario>();
            }
        }

        public Usuario obtenerInfoUsuario(Usuario usuario)
        {
            using (var ctx = new ROYALEPLUSEntities())
            {
                var datos = ctx.USUARIOS.Select(s => new Usuario
                {
                    idUsuario = s.ID_USUARIO,
                    nombre = s.NOMBRE,
                    contrasena = s.CONTRASENA,
                    tipo = s.TIPO,
                    activo = s.ACTIVO ?? false
                }).Where(x => x.nombre == usuario.nombre);

                var resultado = datos.ToList();

                return resultado[0];
            }
        }

        public RespuestaGenerica actualizarUltimaConexion(Usuario usuario)
        {
            try
            {
                using (var ctx = new ROYALEPLUSEntities())
                {
                    ObjectParameter paramMENSAJE = new ObjectParameter("MENSAJE", typeof(string));
                    ObjectParameter paramRETCODE = new ObjectParameter("RETCODE", typeof(int));

                    ctx.PA_ACTUALIZAR_ULTIMA_CONEXION(usuario.idUsuario, paramRETCODE, paramMENSAJE);

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

        public DateTime obtenerUltimaConexion(Usuario usuario)
        {
            // Insercion
            try
            {
                using (var ctx = new ROYALEPLUSEntities())
                {
                    var datos = ctx.USUARIOS.FirstOrDefault(s => s.ID_USUARIO == usuario.idUsuario);

                    return datos.ULTIMA_CONEXION;
                }
            }
            catch (Exception ex)
            {
                return new DateTime();
            }
        }
    }
}
