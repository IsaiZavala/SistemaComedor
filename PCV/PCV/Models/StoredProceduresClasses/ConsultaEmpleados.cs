using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCV.Models.StoredProceduresClasses
{
    public class ConsultaEmpleados
    {
        public string Credencial { get; set; }
        public string PlantaDesc { get; set; }
        public string Nombre { get; set; }
        public string Horario { get; set; }
        public string Subsidio { get; set; }
        public string TipoEmpleado { get; set; }
        public decimal CantidadSubsidio { get; set; }
    }
}
