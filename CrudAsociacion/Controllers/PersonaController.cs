using CrudAsociacion.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudAsociacion.Controllers
{
    public class PersonaController : ApiController
    {
        [HttpPost]
        [Authorize]
        public IHttpActionResult Post([FromBody] PersonaRequest model)
        {
            using (Models.bd_asociacionEntities3 db = new Models.bd_asociacionEntities3())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Models.personas oPersona = new Models.personas();
                        oPersona.ciudad_residencia = model.ciudad_residencia;
                        oPersona.direccion_residencia = model.direccion_residencia;
                        oPersona.dni_persona = model.dni_persona;
                        oPersona.fecha_nacimiento = model.fecha_nacimiento;
                        oPersona.fecha_salida = model.fecha_salida;
                        oPersona.fecha_vencimiento = model.fecha_vencimiento;
                        oPersona.fecha_vinculacion = model.fecha_vinculacion;
                        oPersona.primer_nombre = model.primer_nombre;
                        oPersona.primer_apellido = model.primer_apellido;
                        oPersona.segundo_nombre = model.segundo_nombre;
                        oPersona.segundo_apellido = model.segundo_apellido;
                        oPersona.profesion = model.profesion;
                        oPersona.telefono_celular = model.telefono_celular;
                        db.personas.Add(oPersona);
                        db.SaveChanges();
                        foreach (var oModelDetallePagos in model.detalle_pagos)
                        {
                            Models.detalle_pagos oDetallePago = new Models.detalle_pagos();
                            oDetallePago.fecha_pago = oModelDetallePagos.fecha_pago;
                            oDetallePago.valor_pago = oModelDetallePagos.valor_pago;
                            oDetallePago.id_persona = oPersona.id_persona;
                            db.detalle_pagos.Add(oDetallePago);
                        }

                        db.SaveChanges();
                        dbContextTransaction.Commit();
                        return Ok(new { result = true });

                    }
                    catch(Exception)
                    {
                        dbContextTransaction.Rollback();
                        return Ok(new { result = false });
                    }
                }
            }
                
        }


    }
}
