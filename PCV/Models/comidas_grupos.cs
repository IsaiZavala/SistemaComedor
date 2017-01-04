namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class comidas_grupos
    {
        public short? cgpo_id { get; set; }

        [StringLength(50)]
        public string cgpo_desc { get; set; }

        [Key]
        public bool cgpo_subsidio { get; set; }

        [StringLength(1)]
        public string cgpo_tipo { get; set; }

        public short? cblo_id { get; set; }

        public short? empreu_id { get; set; }

        public DateTime? cgpo_fecha_a { get; set; }

        public DateTime? cgpo_fecha_b { get; set; }

        public short? us_id { get; set; }
    }
}
