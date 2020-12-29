using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CrudAsociacion.Models;
using CrudAsociacion.Models.Request;

namespace CrudAsociacion.Controllers
{
    public class DetallePagosController : ApiController
    {
        private bd_asociacionEntities3 db = new bd_asociacionEntities3();

        // GET: api/DetallePagos
        public IQueryable<detalle_pagos> Getdetalle_pagos()
        {
            return db.detalle_pagos;
        }


        // GET: api/DetallePagos
        public List<DetalleDTO> Getdetalle_pagos_persona(int id_persona)
        {
            return db.detalle_pagos
                .Where(u => u.id_persona == id_persona).Select(u=>new DetalleDTO {fecha_pago=u.fecha_pago, valor_pago = u.valor_pago }).ToList();
        }


        // GET: api/DetallePagos/5
        [ResponseType(typeof(detalle_pagos))]
        public IHttpActionResult Getdetalle_pagos(int id)
        {
            detalle_pagos detalle_pagos = db.detalle_pagos.Find(id);
            if (detalle_pagos == null)
            {
                return NotFound();
            }

            return Ok(detalle_pagos);
        }

        // PUT: api/DetallePagos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdetalle_pagos(int id, detalle_pagos detalle_pagos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detalle_pagos.id_pago)
            {
                return BadRequest();
            }

            db.Entry(detalle_pagos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!detalle_pagosExists(id))
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

        // POST: api/DetallePagos
        [ResponseType(typeof(detalle_pagos))]
        public IHttpActionResult Postdetalle_pagos(detalle_pagos detalle_pagos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.detalle_pagos.Add(detalle_pagos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detalle_pagos.id_pago }, detalle_pagos);
        }

        // DELETE: api/DetallePagos/5
        [ResponseType(typeof(detalle_pagos))]
        public IHttpActionResult Deletedetalle_pagos(int id)
        {
            detalle_pagos detalle_pagos = db.detalle_pagos.Find(id);
            if (detalle_pagos == null)
            {
                return NotFound();
            }

            db.detalle_pagos.Remove(detalle_pagos);
            db.SaveChanges();

            return Ok(detalle_pagos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool detalle_pagosExists(int id)
        {
            return db.detalle_pagos.Count(e => e.id_pago == id) > 0;
        }
    }
}