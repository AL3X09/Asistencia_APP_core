using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace asistencia_rips_APP.Models
{
    //[Keyless]//se usa para tabla sin llave de relación pero no la toma
    public class UserSubDireccionClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //Clave primaria
        
        
        [Display(Name = "Subdireccion")]
        public int SubdireccionId { get; set; } //Campo clave foranea

        [Display(Name = "Nombre Usuario")]
        public virtual string UserId { get; set; }

        //public int UserId { get; set; } //Campo clave foranea
        //public HashSet<IdentityUser> IdentityUser { get; set; }
        //public HashSet<SubdireccionClass> SubdireccionClass { get; set; }
    
        public virtual ApplicationUser User { get; set; }
        //public IdentityUser User { get; set; }
        public SubdireccionClass Subdireccion { get; set; }
    }
}
