namespace PCV.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PCV.Models.StoredProceduresClasses;
    using System.Collections.Generic;

    public partial class ProcterGambleRepository : DbContext
    {
        public ProcterGambleRepository()
            : base("name=ConnectionString")
        {
        }

        public virtual DbSet<comidas> comidas { get; set; }
        public virtual DbSet<COMIDAS_AUX> COMIDAS_AUX { get; set; }
        public virtual DbSet<empleados_clasificacion> empleados_clasificacion { get; set; }
        public virtual DbSet<empresas_usuarias> empresas_usuarias { get; set; }
        public virtual DbSet<pedidos> pedidos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<comidas_grupos> comidas_grupos { get; set; }
        public virtual DbSet<comidas_opciones_menu> comidas_opciones_menu { get; set; }
        public virtual DbSet<empleados> empleados { get; set; }
        public virtual DbSet<impresora> impresora { get; set; }
        public virtual DbSet<impresoras> impresoras { get; set; }
        public virtual DbSet<mails_envio> mails_envio { get; set; }
        public virtual DbSet<mails_generacion_reportes> mails_generacion_reportes { get; set; }
        public virtual DbSet<subsidio> subsidio { get; set; }
        public virtual DbSet<turnos> turnos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<comidas>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<COMIDAS_AUX>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();
        }

        public ConsultaEmpleados ConsultaEmpleados(ConsultaEmpleados finder)
        {
            string HourAndMinute = DateTime.Now.ToString("HH:mm");

            List<ConsultaEmpleados> lstEmpleados = Database.SqlQuery<ConsultaEmpleados>("exec ConsultaEmpleados @p0, @p1", finder.Credencial, HourAndMinute).ToList();

            if (lstEmpleados.Count > 0)
                return lstEmpleados.First();
            
            return new ConsultaEmpleados();
        }

        public List<comidas> ConsultaCatalogoComidas()
        {
            return comidas.ToList();
        }
    }
}
