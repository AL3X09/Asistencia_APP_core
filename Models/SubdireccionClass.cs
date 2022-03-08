using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace asistencia_rips_APP.Models
{
    public class SubdireccionClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //Clave primaria
        
        [Display(Name = "Subdirección")]
        public string Nombre { get; set; }


        [Display(Name = "Dirección")]
        public int DireccionId { get; set; } //Campo clave foranea

        [DefaultValue(true)]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Estado")]
        public bool is_Active { get; set; }
        public DireccionClass Direccion { get; set; } //Objeto de navegación virtual EFC
    }
}
