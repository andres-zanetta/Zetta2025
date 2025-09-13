using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SERVER.Repositorio;
using Zetta.BD.DATA;
using Zetta.BD.DATA.ENTITY;
using Zetta.Shared.DTOS.Obra; // <-- donde están tus DTOs

namespace Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/obra")]
    public class ObraController : ControllerBase
    {
        private readonly IObraRepositorio _obraRepositorio;
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ObraController(IObraRepositorio repositorio, Context context, IMapper mapper)
        {
            this._obraRepositorio = repositorio;
            this._context = context;
            this._mapper = mapper;
        }

        // GET: api/Obra
        [HttpGet]
        public async Task<ActionResult<List<GET_ObraDTO>>> Get()
        {
            var obras = await _obraRepositorio.ObtenerObrasConDetallesAsync();
            var obrasDTO = _mapper.Map<List<GET_ObraDTO>>(obras);
            return Ok(obrasDTO);
        }

        // GET: api/Obra/5
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<GET_ObraDTO>> GetById(int id)
        {
            var obra = await _obraRepositorio.ObtenerObraPorIdConDetallesAsync(id);
            if (obra == null)
            {
                return NotFound("Obra no encontrada.");
            }
            var obraDTO = _mapper.Map<GET_ObraDTO>(obra);
            return Ok(obraDTO);
        }

        // POST: api/Obra
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] POST_ObraDTO obraDTO)
        {
            try
            {
                var obra = _mapper.Map<Obra>(obraDTO);
                var id = await _obraRepositorio.AddAsync(obra);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la obra: {ex.Message}");
            }
        }

        // PUT: api/Obra/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PUT_ObraDTO obraDTO)
        {
            var obraExistente = await _obraRepositorio.ObtenerObraPorIdConDetallesAsync(id);

            if (obraExistente == null)
            {
                return NotFound("Obra no encontrada.");
            }

            var obra = _mapper.Map(obraDTO, obraExistente);

            try
            {
                await _obraRepositorio.UpdateAsync(obra);
                await _context.SaveChangesAsync();
                return Ok("Obra actualizada correctamente.");
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
            await _obraRepositorio.DeleteAsync(id);
            return Ok("Obra eliminada correctamente.");
        }
    }
}
