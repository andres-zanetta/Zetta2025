using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zetta.BD.DATA.ENTITY;

namespace Zetta.Shared.DTOS.Presupuesto
{
    public class PUT_PresupuestoDTO
    {
        public int Id { get; set; } // Identificador del presupuesto a modificar

        public Rubro Rubro { get; set; } // Categoría principal

        public bool Aceptado { get; set; } // Estado de aceptación (puede cambiar)

       // public List<PUT_PresItemDetalleDTO> ItemsDetalle { get; set; } = new List<PUT_PresItemDetalleDTO>();

        public string? Observacion { get; set; } // Comentarios adicionales

        public decimal? ManodeObra { get; set; } = 0.00m;

        public decimal Total { get; set; }

        public decimal TotalP { get; set; } = 0.00m;

        public string TiempoAproxObra { get; set; } = "0";

        public string ValidacionDias { get; set; } = "30";

        public OpcionDePago OpcionDePago { get; set; }
    }
}
