using Zetta.BD.DATA.ENTITY;

namespace Zetta.Shared.DTOS.ItemPresupuesto
{
    public class PUT_ItemPresupuestoDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public Rubro Rubro { get; set; }
        public string? Medida { get; set; }
        public string? Material { get; set; }
        public string? Descripcion { get; set; }
        public string? Fabricante { get; set; }
        public string? Marca { get; set; }
        public DateTime? FechActuPrecio { get; set; }
    }
}
