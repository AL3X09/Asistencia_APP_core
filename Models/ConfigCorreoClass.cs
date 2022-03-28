using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace asistencia_rips_APP.Models
{
    public class ConfigCorreoClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //Clave primaria
        
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        [Display(Name = "Usuario")]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Estado")]
        public bool is_Active { get; set; }
    }
}
