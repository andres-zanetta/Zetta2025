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
        public decimal? Precio { get; set; } // El precio base unitario de este ítem en el catálogo.

        public Rubro Rubro { get; set; } // Rubro al que pertenece este ítem del catálogo.
        public string? Medida { get; set; } 
        public string? Material { get; set; } 

    }


    #region Diccionario
    // | Nombre   | Tipo     | Descripción                                                    |
    // |----------|----------|----------------------------------------------------------------|
    // | Id       | int      | Identificador único del ítem.                                  |
    // | Nombre   | string   | Nombre del ítem. (Obligatorio, no nulo)                        |
    // | Precio   | decimal? | Precio base unitario del ítem en el catálogo.                  |
    // | Rubro    | Rubro    | Rubro al que pertenece el ítem (ej: Gas, Electricidad, etc.).  |
    // | Medida   | string?  | Unidad de medida del ítem (ej: metros, litros).                |
    // | Material | string?  | Material principal del ítem.                                   |
    #endregion

}
