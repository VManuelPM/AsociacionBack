using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudAsociacion.Models
{
    [MetadataType(typeof(UsuarioLoginValidation.MetaData))]
    public partial class UsuarioLoginValidation
    {
        sealed class MetaData
        {
            [Required]
            public string usuario { get; set; }
            [Required]
            public string pass_usuario { get; set; }
        }
    }
}