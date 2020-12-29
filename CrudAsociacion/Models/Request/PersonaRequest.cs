using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudAsociacion.Models.Request
{
    public class PersonaRequest
    {
        public string dni_persona { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string direccion_residencia { get; set; }
        public string ciudad_residencia { get; set; }
        public  int telefono_celular { get; set; }
        public string profesion { get; set; }
        public DateTime fecha_vinculacion { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public DateTime fecha_salida { get; set; }

        public List<DetallePagos> detallePagos { get; set; }
    }

    public class DetallePagos
    {
        public int id_persona { get; set; }
        public decimal valor_pago { get; set; }
        public DateTime fecha_pago { get; set; }

    }
}