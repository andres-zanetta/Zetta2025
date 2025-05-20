using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zetta.BD.DATA
{
    public class EntityBase
    {
        public int Id { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }
    }

}
#region Diccionario:
//public DateTime FechaCreacion { get; set; } = DateTime.Now;
//👉 Marca la fecha y hora en que se creó la entidad(registro).

//e completa automáticamente al crear el objeto.

//Es útil para saber cuándo se hizo el presupuesto, cuándo se registró un cliente, etc.

//se puede usar en reportes, ordenamientos, filtros.

#endregion