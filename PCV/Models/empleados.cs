namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class empleados
    {
        public short? emp_id { get; set; }

        [StringLength(30)]
        public string emp_nombre { get; set; }

        [StringLength(30)]
        public string emp_apellido_p { get; set; }

        [StringLength(30)]
        public string emp_apellido_m { get; set; }

        [StringLength(8)]
        public string emp_no_sap { get; set; }

        [StringLength(10)]
        public string emp_codigo_barras { get; set; }

        public short? cla_id { get; set; }

        public short? cost_id { get; set; }

        public short? puest_id { get; set; }

        public short? pla_id { get; set; }

        public short? empre_id { get; set; }

        public short? fun_id { get; set; }

        public int? foto_id { get; set; }

        [Key]
        [Column(Order = 0)]
        public bool emp_puede_comer { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool emp_puede_comprar { get; set; }

        [StringLength(50)]
        public string emp_mail { get; set; }

        public DateTime? emp_fecha_a { get; set; }

        public DateTime? emp_fecha_m { get; set; }

        public DateTime? emp_fecha_b { get; set; }

        public short? us_id { get; set; }

        [StringLength(50)]
        public string emp_one_key { get; set; }
    }
}
