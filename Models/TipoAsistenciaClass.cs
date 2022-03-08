using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace asistencia_rips_APP.Models
{
    public class TipoAsistenciaClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //Clave primaria

        [Display(Name = "Tipo de Asistencia")]
        [Required(AllowEmptyStrings = false)]
        public string Nombre { get; set; }
        
        [Display(Name = "Estado")]
        [DefaultValue(true)]
        public bool is_Active { get; set; }
    }
}
