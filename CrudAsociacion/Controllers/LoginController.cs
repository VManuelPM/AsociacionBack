using CrudAsociacion.Models;
using CrudAsociacion.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.Http;

namespace CrudAsociacion.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {

        private bd_asociacionEntities3 db = new bd_asociacionEntities3();

        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        public List<LoginRequest> findByUsername(string username)
        {
            return db.usuario_login
                .Where(u => u.usuario == username)
                .Select(u => new LoginRequest { usuario = u.usuario, pass_usuario = u.pass_usuario })
                .ToList();
                
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            bool isCredentialValid = false;
            bool isUserValid = false;

            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            List<LoginRequest> usuario = findByUsername(login.usuario);

            if (usuario.Count > 0)
            {
                foreach (LoginRequest u in usuario) {
                    isCredentialValid = (login.pass_usuario == u.pass_usuario.Trim());
                    isUserValid = (login.usuario == u.usuario.Trim());
                }

                if (isCredentialValid && isUserValid)
                {
                    var token = TokenGenerator.GenerateTokenJwt(login.usuario);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return InternalServerError();
            }

        }
    }
}