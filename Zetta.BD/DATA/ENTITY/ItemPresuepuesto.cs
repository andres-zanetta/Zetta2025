using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.BD.DATA.ENTITY
{
    public class ItemPresupuesto : EntityBase
    {
        [Required] // Hace que el Nombre sea obligatorio.
        public required string Nombre { get; set; } // Nombre del ítem de catálogo (ej: "Codo 90 grados").

        [Precision(18, 2)] // Define la precisión y escala para el tipo decimal en la base de datos.
        public decimal? Precio { get; set; } 

        public Rubro Rubro { get; set; } 
        public string? Medida { get; set; }
        public string? Material { get; set; }
        public string? Descripcion { get; set; }
        public string? Fabricante { get; set; }
        public string? Marca { get; set; }
        public DateTime? FechActuPrecio { get; set; }
    }

    #region Diccionario
    // | Nombre                     | Tipo           | Descripción                                                                 |
    // |----------------------------|----------------|-----------------------------------------------------------------------------|
    // | Id                         | int            | Identificador único del ítem.                                               |
    // | Nombre                     | string         | Nombre del ítem. (Obligatorio, no nulo)                                     |
    // | Descripcion                | string?        | Una descripción más detallada del ítem.                                     |
    // | Precio                     | decimal?       | Precio base unitario del ítem en el catálogo.                               |
    // | Rubro                      | Rubro          | Rubro al que pertenece el ítem (ej: Gas, Electricidad, etc.).               |
    // | Medida                     | string?        | Unidad de medida del ítem (ej: metros, litros, pulgadas).                   |
    // | Material                   | string?        | Material principal del ítem.                                               |
    // | Fabricante                 | string?        | Nombre del fabricante del ítem.                                             |
    // | Marca                      | string?        | Marca específica del ítem.                                                  |
    // | FechActuPrecio             | DateTime?      | Fecha de la última vez que se actualizó el precio del ítem.
    #endregion

}
