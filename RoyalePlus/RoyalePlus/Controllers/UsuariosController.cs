using RoyalePlusDatos.DTO;
using RoyalePlusNegocio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RoyalePlus.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [System.Web.Http.RoutePrefix("api/royaleplus")]
    public class UsuariosController : ApiController
    {
        [HttpGet]
        [Route("obtenerUsuarios")]
        public HttpResponseMessage obtenerUsuarios()
        {
            try
            {
                var usuGes = new UsuariosGestion();
                var resultado = usuGes.TodosLosUsuarios();

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { isError = true, data = ex.Message });
            }
        }

        [HttpPost]
        [Route("obtenerInfoUsuario")]
        public HttpResponseMessage obtenerInfoUsuario(Usuario usuario)
        {
            try
            {
                var usuGes = new UsuariosGestion();
                var resultado = usuGes.obtenerInfoUsuario(usuario);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { isError = true, data = ex.Message });
            }
        }

        [HttpPost]
        [Route("actualizarUltimaConexion")]
        public HttpResponseMessage actualizarUltimaConexion(Usuario usuario)
        {
            try
            {
                var usuGes = new UsuariosGestion();
                var resultado = usuGes.actualizarUltimaConexion(usuario);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { isError = true, data = ex.Message });
            }
        }

        [HttpPost]
        [Route("obtenerUltimaConexion")]
        public HttpResponseMessage obtenerUltimaConexion(Usuario usuario)
        {
            try
            {
                var usuGes = new UsuariosGestion();
                var resultado = usuGes.obtenerUltimaConexion(usuario);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { isError = true, data = ex.Message });
            }
        }
    }
}
