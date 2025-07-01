using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zetta.BD.DATA;
using Zetta.BD.DATA.ENTITY;

namespace Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/PressItemDetalle")]
    public class PresItemDetalleController : ControllerBase
    {
        private readonly Context context;

        public PresItemDetalleController(Context context)
        {
            this.context = context;
        }

        // GET: api/PresItemDetalle
        [HttpGet]
        public async Task<ActionResult<List<PresItemDetalle>>> Get()
        {
            return await context.PresItemDetalles
                                .Include(d => d.Presupuesto)
                                .Include(d => d.ItemPresupuesto)
                                .ToListAsync();
        }

        // GET: api/PresItemDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PresItemDetalle>> GetById(int id)
        {
            var detalle = await context.PresItemDetalles
                                       .Include(d => d.Presupuesto)
                                       .Include(d => d.ItemPresupuesto)
                                       .FirstOrDefaultAsync(d => d.Id == id);

            if (detalle == null)
                return NotFound("Detalle de presupuesto no encontrado.");

            return detalle;
        }

        // POST: api/PresItemDetalle
        [HttpPost]
        public async Task<ActionResult<int>> Post(PresItemDetalle detalle)
        {
            try
            {
                context.PresItemDetalles.Add(detalle);
                await context.SaveChangesAsync();
                return detalle.Id;
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el detalle: {ex.Message}");
            }
        }

        // PUT: api/PresItemDetalle/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PresItemDetalle detalle)
        {
            if (id != detalle.Id)
                return BadRequest("ID no coincide.");

            var dbDetalle = await context.PresItemDetalles.FindAsync(id);
            if (dbDetalle == null)
                return NotFound("Detalle no encontrado.");

            dbDetalle.PresupuestoId = detalle.PresupuestoId;
            dbDetalle.ItemPresupuestoId = detalle.ItemPresupuestoId;
            dbDetalle.Cantidad = detalle.Cantidad;
            dbDetalle.PrecioUnitario = detalle.PrecioUnitario;

            try
            {
                context.PresItemDetalles.Update(dbDetalle);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el detalle: {ex.Message}");
            }
        }

        // DELETE: api/PresItemDetalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var detalle = await context.PresItemDetalles.FindAsync(id);
            if (detalle == null)
                return NotFound("Detalle no encontrado.");

            try
            {
                context.PresItemDetalles.Remove(detalle);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar el detalle: {ex.Message}");
            }
        }
    }
}

