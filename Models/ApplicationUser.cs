using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace asistencia_rips_APP.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        [PersonalData]
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }
        
        [PersonalData]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

    }
}
