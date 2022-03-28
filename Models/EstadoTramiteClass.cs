using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace asistencia_rips_APP.Models
{
    public class EstadoTramiteClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //Clave primaria

        [Required(ErrorMessage = "El Campo es obligatorio")]
        [Display(Name = "Nombre Estado")]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Required]
        public bool is_Active { get; set; }
    }
}
