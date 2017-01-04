namespace PCV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class empleados_clasificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short cla_id { get; set; }

        [StringLength(50)]
        public string cla_descripcion { get; set; }

        public bool cla_habilitado_c { get; set; }

        public bool cla_habilitado_t { get; set; }

        public bool cla_subsidio { get; set; }

        public DateTime? cla_fecha_a { get; set; }

        public DateTime? cla_fecha_b { get; set; }

        public short? us_id { get; set; }
    }
}
