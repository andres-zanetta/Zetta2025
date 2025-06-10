using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.BD.DATA.ENTITY
{
    public class ItemPresupuesto : EntityBase
    {
        public required string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public Rubro Rubro { get; set; } // Ej: Electricidad, Gas, etc.
        public string? Medida { get; set; }
        public string? Material { get; set; }
    }

    public enum Rubro
{
    Gas,
    Electricidad,
    Refrigeracion,
    Solar,
    Plomeria
}


    // Diccionario
    // | Nombre   | Tipo    | Descripción                                       |
    // |----------|---------|---------------------------------------------------|               |
    // | Nombre   | string  | Nombre del ítem. (No nulo)             |
    // | Precio   | decimal | Precio del ítem.                                  |
    // | Rubro    | Rubro   | Rubro al que pertenece (no nulo).                 |
    // | Medida   | string  | Unidad de medida del ítem (ej: metros, litros).   |
    // | Material | string  | Material principal del ítem.                     

}
