using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.BD.DATA.ENTITY
{
    public class ItemPresupuesto : EntityBase
    {
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;

        public int PresupuestoId { get; set; }
        public Presupuesto Presupuesto { get; set; }

        public string Categoria { get; set; } // Ej: Electricidad, Gas, etc.
        public bool IncluyeMateriales { get; set; }
    }

    //Diccionario
//    | Nombre              | Tipo      | Descripción                                      |
//| ------------------- | --------- | ------------------------------------------------ |
//| `Descripcion`       | `string`  | Detalle del trabajo, ítem o servicio.            |
//| `Cantidad`          | `int`     | Número de unidades.                              |
//| `PrecioUnitario`    | `decimal` | Precio por unidad.                               |
//| `Subtotal`          | `decimal` | Resultado de cantidad \* precio.                 |
//| `IncluyeMateriales` | `bool`    | Si el ítem incluye materiales o no.              |
//| `Categoria`         | `string`  | Clasificación (ej: electricidad, gas, plomería). |


}
