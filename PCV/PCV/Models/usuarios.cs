namespace PCV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short us_id { get; set; }

        [StringLength(30)]
        public string us_nombre { get; set; }

        [StringLength(30)]
        public string us_apellido_p { get; set; }

        [StringLength(30)]
        public string us_apellido_m { get; set; }

        [StringLength(30)]
        public string us_clave { get; set; }

        public short? empreu_id { get; set; }

        public bool mnu_catalogos { get; set; }

        public bool mnu_movimientos { get; set; }

        public bool mnu_reportes { get; set; }

        public bool mnu_configurar { get; set; }

        public bool mnu_replica { get; set; }

        public bool bh_tecnicos { get; set; }

        public bool bh_administrativos { get; set; }

        public bool bh_becarios { get; set; }

        public bool bh_practicantes { get; set; }

        public bool bh_contratistas { get; set; }

        public bool bh_internacionales { get; set; }

        public bool bh_directores { get; set; }

        public bool bh_comidas { get; set; }

        public bool bh_comedor { get; set; }

        public bool bh_comedor_man { get; set; }

        public bool bh_cda_new { get; set; }

        public bool bh_cda_admin { get; set; }

        public bool bh_lt_opciones { get; set; }

        public bool bh_lt_menu { get; set; }

        public bool bh_usuarios { get; set; }

        public DateTime? us_fecha_a { get; set; }

        public DateTime? us_fecha_b { get; set; }

        public int? uss_id { get; set; }
    }
}
