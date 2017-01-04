namespace PCV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class comidas_opciones_menu
    {
        public int? lt_id { get; set; }

        public DateTime? lt_fecha { get; set; }

        public int? co1_id { get; set; }

        public int? co2_id { get; set; }

        public int? co3_id { get; set; }

        [StringLength(50)]
        public string lt_motivo3 { get; set; }

        public int? co4_id { get; set; }

        [StringLength(50)]
        public string lt_motivo4 { get; set; }

        public DateTime? lt_fecha_a { get; set; }

        public DateTime? lt_fecha_b { get; set; }

        public short? us_id { get; set; }

        [Key]
        public bool tradicional { get; set; }
    }
}
