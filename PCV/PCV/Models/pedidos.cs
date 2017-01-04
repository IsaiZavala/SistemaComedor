namespace PCV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pedidos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ped_id { get; set; }

        public DateTime? ped_fecha_a { get; set; }

        public DateTime? ped_fecha_b { get; set; }

        public short? emp_id { get; set; }

        [StringLength(2)]
        public string ped_estatus { get; set; }

        [StringLength(10)]
        public string ped_numero { get; set; }

        public short? ped_no_cajas { get; set; }

        public DateTime? ped_hora { get; set; }

        public short? us_id { get; set; }
    }
}
