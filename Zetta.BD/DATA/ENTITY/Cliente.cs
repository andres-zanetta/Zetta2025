using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.BD.DATA.ENTITY
{
    public class Cliente : EntityBase
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string?Localidad { get; set; }
        public string Telefono { get; set; }
        public string? Email { get; set; }

        public ICollection<Presupuesto> Presupuestos { get; set; }
    }
    #region Diccionario
    //| Nombre      | Tipo     | Descripción                    |
    //| ----------- | -------- | ------------------------------ |
    //| `Id`        | `int`    | Identificador único.           |
    //| `Nombre`    | `string` | Nombre del cliente.            |
    //| `Apellido`  | `string` | Apellido del cliente.          |
    //| `Direccion` | `string` | Domicilio del cliente.         |
    //| `Localidad` | `string` | Ciudad o barrio del cliente.   |
    //| `Telefono`  | `string` | Teléfono de contacto. NoNull   |
    //| `Email`     | `string` | Correo electrónico.            |
    #endregion
}
