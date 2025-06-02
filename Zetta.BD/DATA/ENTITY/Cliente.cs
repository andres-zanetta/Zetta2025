using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.BD.DATA.ENTITY
{
    public class Cliente : EntityBase
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public ICollection<Presupuesto> Presupuestos { get; set; }
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
