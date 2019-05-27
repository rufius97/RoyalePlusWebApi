﻿using RoyalePlusDatos.DTO;
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
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage login(Usuario usuario)
        {
            try
            {
                var logGes = new LoginGestion();
                var resultado = logGes.login(usuario);



                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { isError = true, data = ex.Message });
            }
        }
    }
}
