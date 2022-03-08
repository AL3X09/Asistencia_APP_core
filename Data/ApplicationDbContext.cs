using asistencia_rips_APP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace asistencia_rips_APP.Data
{
    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

        

        public DbSet<DireccionClass> Direccion { get; set; }
        public DbSet<SubdireccionClass> Subdireccion { get; set; }
        public DbSet<UserSubDireccionClass> UserSubdireccion { get; set; }
        public DbSet<TipoAsistenciaClass> Tipoasistencia { get; set; }
        public DbSet<TemaClass> Tema { get; set; }
        public DbSet<FormAsistenciaClass> Formasistencia { get; set; }
        public DbSet<ConfigCorreoClass> Configcorreo { get; set; }
        public DbSet<EstadoTramiteClass> EstadoTramite { get; set; }

    }
}
