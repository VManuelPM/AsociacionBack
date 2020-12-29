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
    public class PersonasController : ApiController
    {
        private bd_asociacionEntities3 db = new bd_asociacionEntities3();

        // GET: api/Personas
        [Authorize]
        public IQueryable<personas> Getpersonas()
        {
            return db.personas;
        }

        // GET: api/Personas/5
        [ResponseType(typeof(personas))]
        public IHttpActionResult Getpersonas(int id)
        {
            personas personas = db.personas.Find(id);
            if (personas == null)
            {
                return NotFound();
            }

            return Ok(personas);
        }

        // PUT: api/Personas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpersonas(int id, personas personas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personas.id_persona)
            {
                return BadRequest();
            }

            db.Entry(personas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!personasExists(id))
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

        // POST: api/Personas
        [ResponseType(typeof(personas))]
        public IHttpActionResult Postpersonas(personas personas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.personas.Add(personas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personas.id_persona }, personas);
        }

        // DELETE: api/Personas/5
        [ResponseType(typeof(personas))]
        public IHttpActionResult Deletepersonas(int id)
        {
            personas personas = db.personas.Find(id);
            if (personas == null)
            {
                return NotFound();
            }

            db.personas.Remove(personas);
            db.SaveChanges();

            return Ok(personas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool personasExists(int id)
        {
            return db.personas.Count(e => e.id_persona == id) > 0;
        }
    }
}