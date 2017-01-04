namespace PCV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class empresas_usuarias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short empreu_id { get; set; }

        [StringLength(10)]
        public string empreu_codigo { get; set; }

        [StringLength(60)]
        public string empreu_desc { get; set; }

        public DateTime? empreu_fecha_a { get; set; }

        public DateTime? empreu_fecha_b { get; set; }

        public short? us_id { get; set; }
    }
}
