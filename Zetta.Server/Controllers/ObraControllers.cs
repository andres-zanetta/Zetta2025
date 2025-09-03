using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SERVER.Repositorio;
using Zetta.BD.DATA;
using Zetta.BD.DATA.ENTITY;

namespace Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/obra")]
    public class ObraController : ControllerBase
    {
        private readonly IObraRepositorio _obraRepositorio;

        public ObraController(IObraRepositorio repositorio)
        {
            this._obraRepositorio = repositorio;
        }

        // Reemplaza el método Get para convertir el IEnumerable<Obra> en List<Obra>
        [HttpGet]
        public async Task<ActionResult<List<Obra>>> Get()
        {
            var obras = await _obraRepositorio.ObtenerObrasConDetallesAsync();
            return Ok(obras.ToList());
        }

        // GET: api/Obra/5
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Obra>> GetById(int id)
        {
            Obra? obra = await _obraRepositorio.ObtenerObraPorIdConDetallesAsync(id);
            if (obra == null)
            {
                return NotFound("Obra no encontrada.");
            }
            return obra;

        }

        // POST: api/Obra
        [HttpPost]
        public async Task<ActionResult<int>> Post(Obra obra)
        {
            try
            {
                
                return await _obraRepositorio.Insert(obra);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la obra: {ex.Message}");
            }
        }

        // PUT: api/Obra/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Obra obra)
        {
            if (id != obra.Id)
            { return BadRequest("ID no coincide."); }
             
            var dbObra = await _obraRepositorio.UpdateAsync(id, obra);

            if (dbObra == null)
                return NotFound("Obra no encontrada.");

            dbObra.EstadoObra = obra.EstadoObra;
            dbObra.PresupuestoId = obra.PresupuestoId;
            dbObra.FechaInicio = obra.FechaInicio;
            dbObra.Comentarios = obra.Comentarios;
           // dbObra.Cliente = obra.Cliente;

            try
            {
                _obraRepositorio.Obras.Update(dbObra);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar la obra: {ex.Message}");
            }
        }

        // DELETE: api/Obra/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var obra = await Delete(id);
            if (obra == null)
            { return NotFound("Obra no encontrada."); }
            return Ok("Obra eliminada correctamente.");


        }
    }
}
