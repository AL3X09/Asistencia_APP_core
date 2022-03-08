using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//https://www.fixedbuffer.com/entity-framework-core-2/
namespace asistencia_rips_APP.Models
{
    public class DireccionClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //Clave primaria

        [Required(ErrorMessage = "El Campo es obligatorio")]
        [Display(Name = "Nombre Dirección")]
        public string Nombre { get; set; }

        [DefaultValue(true)]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Estado")]
        public bool is_Active { get; set; }
        //Entity Framewrok Core
        //public IdentityUser User { get; set; } //Objeto de navegación virtual EFC
    }
}
