using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.BD.DATA.ENTITY
{
    public class Presupuesto:EntityBase
    {
        public int MyProperty { get; set; }

        public DateTime Fecha { get; set; }

        //public char Estado { get; set; } // Aceptado, Rechazado, Pendiente

        public string MedioDePago { get; set; } // Efectivo, Transferencia, Tarjeta

        public decimal Total { get; set; }

        public string Observaciones { get; set; } // Observaciones del presupuesto
    }
}
