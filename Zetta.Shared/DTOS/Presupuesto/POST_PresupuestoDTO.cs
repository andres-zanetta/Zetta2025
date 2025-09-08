using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zetta.BD.DATA.ENTITY;
using Zetta.Shared.DTOS.ItemPresupuesto;

namespace Zetta.Shared.DTOS.Presupuesto
{
    public class POST_PresupuestoDTO
    {
        public Rubro Rubro { get; set; } // Categoría principal (ej: Gas, Electricidad).

        public bool Aceptado { get; set; } = false; // Estado inicial (por defecto en false).

        // Lista de ítems que se agregan al presupuesto
       // public List<POST_PresItemDetalleDTO> ItemsDetalle { get; set; } = new List<POST_PresItemDetalleDTO>(); esperar a que lo tenga hecho

        public string? Observacion { get; set; } // Comentarios adicionales.

        public decimal? ManodeObra { get; set; } = 0.00m; // Costo de mano de obra (opcional).

        public decimal Total { get; set; } // Monto total final del presupuesto.

        public decimal TotalP { get; set; } = 0.00m; // Campo adicional.

        public string TiempoAproxObra { get; set; } = "0"; // Tiempo estimado de la obra.

        public string ValidacionDias { get; set; } = "30"; // Días de validez.

        public OpcionDePago OpcionDePago { get; set; } // Método de pago seleccionado.

        // Items que componen el presupuesto
        public required List<GET_ItemPresupuestoDTO> Items { get; set; }
    }

}
