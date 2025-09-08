using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.Shared.DTOS.Obra
{
    public class POST_ObraDTO
    {
        public string EstadoObra { get; set; } = "Iniciada"; // default
        public int PresupuestoId { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public int ClienteId { get; set; }
    }
}
