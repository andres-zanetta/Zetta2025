using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.Shared.DTOS.PresItemDetalle
{
    public class PUT_PresItemDetalleDTO
    {
        public int Id { get; set; } // Añadimos el Id para identificar el ítem a actualizar/eliminar
        public int ItemPresupuestoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
