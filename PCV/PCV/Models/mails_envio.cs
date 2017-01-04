namespace PCV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mails_envio
    {
        [StringLength(50)]
        public string sap { get; set; }

        [Key]
        public bool no_mail { get; set; }
    }
}
