using asistencia_rips_APP.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace asistencia_rips_APP.Models
{
    public class UsuarioClass
    {
        public int id { get; set; }

        [Required]
        [EmailAddress]
        public string correo { get; set; }

        [Required]
        [ContrasenaValidate(ErrorMessage = "Contraseña no valida")]
        public string contrasena { get; set; }

        [Required]
        public string nombres { get; set; }
        
        [Required]
        public string apellidos { get; set; }

        [Required]
        public string dependencia { get; set; }

        [Required]
        public string firma { get; set; }

        public bool is_valid { get; set; }
        public DateTime? fechaReg { get; set; }
    }
}
