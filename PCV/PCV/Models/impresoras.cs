namespace PCV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class impresoras
    {
        public short? impre_id { get; set; }

        [Key]
        [Column(Order = 0)]
        public bool impre_ticket_tienda { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool impre_ticket_comedor { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool impre_pto_serie_tienda { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool impre_pto_paralelo_tienda { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool impre_pto_serie_comedor { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool impre_pto_paralelo_comedor { get; set; }

        public short? us_id { get; set; }
    }
}
