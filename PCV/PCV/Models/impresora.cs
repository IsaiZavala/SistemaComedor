namespace PCV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("impresora")]
    public partial class impresora
    {
        [Key]
        public bool pto_serie { get; set; }

        public int? pto_id { get; set; }
    }
}
