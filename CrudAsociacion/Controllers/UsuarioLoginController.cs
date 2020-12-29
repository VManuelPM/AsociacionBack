using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CrudAsociacion.Models;

namespace CrudAsociacion.Controllers
{
    public class UsuarioLoginController : ApiController
    {
        private bd_asociacionEntities3 db = new bd_asociacionEntities3();

        // GET: api/usuarioLogin
        public IQueryable<usuario_login> Getusuario_login()
        {
            return db.usuario_login;
        }

        // GET: api/usuarioLogin/5
        [ResponseType(typeof(usuario_login))]
        public IHttpActionResult Getusuario_login(int id)
        {
            usuario_login usuario_login = db.usuario_login.Find(id);
            if (usuario_login == null)
            {
                return NotFound();
            }

            return Ok(usuario_login);
        }

        // PUT: api/usuarioLogin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putusuario_login(int id, usuario_login usuario_login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario_login.id_usuario)
            {
                return BadRequest();
            }

            db.Entry(usuario_login).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuario_loginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/usuarioLogin
        [ResponseType(typeof(usuario_login))]
        public IHttpActionResult Postusuario_login(usuario_login usuario_login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.usuario_login.Add(usuario_login);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuario_login.id_usuario }, usuario_login);
        }

        // DELETE: api/usuarioLogin/5
        [ResponseType(typeof(usuario_login))]
        public IHttpActionResult Deleteusuario_login(int id)
        {
            usuario_login usuario_login = db.usuario_login.Find(id);
            if (usuario_login == null)
            {
                return NotFound();
            }

            db.usuario_login.Remove(usuario_login);
            db.SaveChanges();

            return Ok(usuario_login);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usuario_loginExists(int id)
        {
            return db.usuario_login.Count(e => e.id_usuario == id) > 0;
        }
    }
}