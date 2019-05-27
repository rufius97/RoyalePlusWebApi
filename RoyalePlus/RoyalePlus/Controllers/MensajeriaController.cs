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
    public class MensajeriaController : ApiController
    {
        [HttpPost]
        [Route("obtenerTodosChatsDeUnUsuario")]
        public HttpResponseMessage obtenerTodosChatsDeUnUsuario(Usuario usuario)
        {
            try
            {
                var menGes = new MensajeriaGestion();
                var resultado = menGes.obtenerTodosChatsDeUnJugador(usuario);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { isError = true, data = ex.Message });
            }
        }

        [HttpPost]
        [Route("obtener100MensajesDeUnChat")]
        public HttpResponseMessage obtener100MensajesDeUnChat(Chat chat)
        {
            try
            {
                var menGes = new MensajeriaGestion();
                var resultado = menGes.obtener100MensajesDeUnChat(chat);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { isError = true, data = ex.Message });
            }
        }

        [HttpPost]
        [Route("enviarMensaje")]
        public HttpResponseMessage enviarMensaje(Mensaje mensaje)
        {
            try
            {
                var menGes = new MensajeriaGestion();
                var resultado = menGes.enviarMensaje(mensaje);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { isError = true, data = ex.Message });
            }
        }

        [HttpPost]
        [Route("obtenerMensajesNuevos")]
        public HttpResponseMessage obtenerMensajesNuevos(Mensaje mensaje)
        {
            try
            {
                var menGes = new MensajeriaGestion();
                var resultado = menGes.obtenerMensajesNuevos(mensaje);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { isError = true, data = ex.Message });
            }
        }

        [HttpPost]
        [Route("marcarComoLeidoTodo")]
        public HttpResponseMessage marcarComoLeidoTodo(Chat chat)
        {
            try
            {
                var menGes = new MensajeriaGestion();
                var resultado = menGes.marcarComoLeidoTodo(chat);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { isError = true, data = ex.Message });
            }
        }
    }
}
