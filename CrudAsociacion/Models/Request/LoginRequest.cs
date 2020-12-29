using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudAsociacion.Models.Request
{
    public class LoginRequest
    {
        public string usuario { get; set; }
        public string pass_usuario { get; set; }
    }
}