using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.BD.DATA.ENTITY
{
    public class Presupuesto:EntityBase
    {
        public int MyProperty { get; set; }

        [Required(ErrorMessage = "La fecha de alta es obligatoria.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaAlta { get; set; }

        //public char Estado { get; set; } // Aceptado, Rechazado, Pendiente

        public string MedioDePago { get; set; } // Efectivo, Transferencia, Tarjeta

        public decimal Total { get; set; }

        public string Observaciones { get; set; } // Observaciones del presupuesto
    }
}
