using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace asistencia_rips_APP.Models
{
    public class FormAsistenciaClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //Clave primaria

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Consecutivo")]
        public int Consec { get; set; }

        [DataType(DataType.Date)]  
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Nombres Contacto")]
        public string Nombres_contacto { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Apellidos Contacto")]
        public string Apellidos_contacto { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Datos Contacto")]
        public string Datos_contacto { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Acciones")]
        public string Acciones { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Compromisos")]
        public string Compromisos { get; set; }

        [Display(Name = "Firma")]
        public string Firma { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Tema")]
        public int TemaId { get; set; } //Campo clave foranea
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Tipo Asistencia")]
        public int TipoAsistenciaId { get; set; } //Campo clave foranea

        [Display(Name = "Nombre Usuario")]
        public virtual string UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Estado de la Asistencia")]
        public virtual int EstadoTramiteId { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Estado")]
        public bool is_Active { get; set; }

        public TemaClass Tema { get; set; } //Objeto de navegación virtual EFC
        public TipoAsistenciaClass TipoAsistencia { get; set; } //Objeto de navegación virtual EFC
        public ApplicationUser User { get; set; }
        public EstadoTramiteClass EstadoTramite { get; set; }
    }
}
