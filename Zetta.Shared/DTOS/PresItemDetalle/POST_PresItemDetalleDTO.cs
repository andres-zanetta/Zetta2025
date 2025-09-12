using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.Shared.DTOS.PresItemDetalle
{
    public class POST_PresItemDetalleDTO
    {
        public int ItemPresupuestoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
