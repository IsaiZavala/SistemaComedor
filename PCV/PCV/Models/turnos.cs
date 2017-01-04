namespace PCV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class turnos
    {
        public short? tu_id { get; set; }

        public DateTime? tu_hora_ini { get; set; }

        public DateTime? tu_hora_fin { get; set; }

        public int? tu_dia { get; set; }

        [Key]
        [Column(Order = 0)]
        public bool tu_subsidio { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool tu_venta { get; set; }

        public int? tu_lim_comidas { get; set; }

        public DateTime? tu_fecha_a { get; set; }

        public DateTime? tu_fecha_b { get; set; }

        public short? us_id { get; set; }

        public float? subsidio { get; set; }
    }
}
