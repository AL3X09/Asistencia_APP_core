using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace asistencia_rips_APP.Models
{
    public class TemaClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //Clave primaria

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre Tema")]
        public string Nombre { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Estado")]
        public bool is_Active { get; set; }
    }
}
