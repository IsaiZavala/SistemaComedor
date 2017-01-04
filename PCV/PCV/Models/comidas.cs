namespace PCV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class comidas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short com_id { get; set; }

        [StringLength(50)]
        public string com_descripcion { get; set; }

        public float? pre_precio { get; set; }

        [StringLength(5)]
        public string com_codigo { get; set; }

        public bool com_granel { get; set; }

        public bool com_default { get; set; }

        public bool com_lt { get; set; }

        public short? cgpo_id { get; set; }

        public short? cblo_id { get; set; }

        public short? empreu_id { get; set; }

        public DateTime? com_fecha_a { get; set; }

        public DateTime? com_fecha_b { get; set; }

        public short? us_id { get; set; }

        public float? com_montosubsidio { get; set; }

        public int? com_nosubsidiadas { get; set; }

        public bool com_subsidio { get; set; }

        public bool com_iva { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
