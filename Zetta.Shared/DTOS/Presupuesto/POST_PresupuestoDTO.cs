using System;
using System.Collections.Generic;
using Zetta.BD.DATA.ENTITY;
using Zetta.Shared.DTOS.ItemPresupuesto;
using Zetta.Shared.DTOS.PresItemDetalle;

namespace Zetta.Shared.DTOS.Presupuesto
{
    public class POST_PresupuestoDTO
    {
        public Rubro Rubro { get; set; }
        public bool Aceptado { get; set; } = false;
        public string? Observacion { get; set; }
        public decimal? ManodeObra { get; set; }
        public decimal Total { get; set; }
        public decimal TotalP { get; set; }
        public string TiempoAproxObra { get; set; }
        public string ValidacionDias { get; set; }
        public OpcionDePago OpcionDePago { get; set; }
        public required int ClienteId { get; set; } // Añadir la propiedad para el cliente
        public List<POST_PresItemDetalleDTO>? ItemsDetalle { get; set; }
    }
}