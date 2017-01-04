using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCV.WEB.Objects
{
    public class Producto
    {
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Recuperacion { get; set; }
        public decimal Total { get; set; }
        public string SUBI { get; set; }
        public string IVA { get; set; }
    }
}