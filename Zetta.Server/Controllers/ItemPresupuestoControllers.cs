using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zetta.BD.DATA;
using Zetta.BD.DATA.ENTITY;

namespace Zetta.SERVER.Controllers
{
    [ApiController]
    [Route("api/ItemPresupuesto")]
    public class ItemPresupuestoController : ControllerBase
    {
        private readonly Context context;

        public ItemPresupuestoController(Context context)
        {
            this.context = context;
        }

        // GET: api/ItemPresupuesto
        [HttpGet]
        public async Task<ActionResult<List<ItemPresupuesto>>> Get()
        {
            return await context.ItemPresupuestos.ToListAsync();
        }

        // POST: api/ItemPresupuesto
        [HttpPost]
        public async Task<ActionResult<int>> Post(ItemPresupuesto entidad)
        {
            try
            {
                context.ItemPresupuestos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/ItemPresupuesto/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ItemPresupuesto entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var item = await context.ItemPresupuestos
                                    .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return NotFound("No se encontró el ítem.");
            }

            // Asignación de valores actualizados
            item.Nombre = entidad.Nombre;
            item.Precio = entidad.Precio;
            item.Rubro = entidad.Rubro;
            item.Medida = entidad.Medida;
            item.Material = entidad.Material;
            item.Descripcion = entidad.Descripcion;
            item.Fabricante = entidad.Fabricante;
            item.Marca = entidad.Marca;
            item.FechActuPrecio = entidad.FechActuPrecio;

            try
            {
                context.ItemPresupuestos.Update(item);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ItemPresupuesto/{id}
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await context.ItemPresupuestos.FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return NotFound("No se encontró el ítem con ese ID.");
            }

            try
            {
                context.ItemPresupuestos.Remove(item);
                await context.SaveChangesAsync();
                return Ok("Ítem eliminado correctamente.");
            }
            catch (Exception e)
            {
                return BadRequest($"Error al eliminar el ítem: {e.Message}");
            }
        }

    }
}

