using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.Shared.DTOS.Obra
{
    public class GET_ObraDTO
    {
        public int Id { get; set; }
        public string EstadoObra { get; set; } = string.Empty; // Enum en string legible
        public int PresupuestoId { get; set; }
        public DateTime FechaInicio { get; set; }

        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; } = string.Empty;

        // Si quiero devolver comentarios
        public List<string>? Comentarios { get; set; }

    }
}
