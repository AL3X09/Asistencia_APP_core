﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asistencia_rips_APP.Models
{
    public class ApplicationRole : IdentityRole<string>
    {
        public string Description { get; set; }
    }
}
