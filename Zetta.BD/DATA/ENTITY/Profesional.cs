using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zetta.BD.DATA.ENTITY
{
    public class Profesional : EntityBase
    {
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public decimal Comision { get; set; } = 0.05m;

        public ICollection<Obra> ObrasDerivadas { get; set; }
    }

    //Diccionario
//| Nombre      | Tipo     | Descripción                    |
//| ----------- | -------- | ------------------------------ |
//| `Id`        | `int`    | Identificador único.           |
//| `Nombre`    | `string` | Nombre y apellido del cliente. |
//| `Direccion` | `string` | Domicilio del cliente.         |
//| `Localidad` | `string` | Ciudad o barrio del cliente.   |
//| `Telefono`  | `string` | Teléfono de contacto.          |
//| `Email`     | `string` | Correo electrónico.            |


}
