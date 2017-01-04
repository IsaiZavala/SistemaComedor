namespace PCV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("subsidio")]
    public partial class subsidio
    {
        public short? sub_id { get; set; }

        [Key]
        public bool sub_limite { get; set; }

        public float? sub_porcentaje { get; set; }

        public float? sub_subsidio_ge { get; set; }

        public DateTime? sub_fecha_a { get; set; }

        public DateTime? sub_fecha_b { get; set; }

        public short? us_id { get; set; }
    }
}
